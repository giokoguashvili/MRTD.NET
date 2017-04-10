using SmartCardApi.Infrastructure;
using SmartCardApi.MRZ;
using SmartCardApi.SecureMessaging;

namespace SmartCardApi.SmartCard.Reader
{
    public class SecuredReader : IReader
    {
        private readonly IReader _reader;
        private readonly ISessionKeys _sessionKeys;
        private IBinary _selfIncrementedSSC;
        public SecuredReader(
                ISymbols mrzInfo,
                IReader reader
            )
        {
            _reader = reader;
            _sessionKeys = new SessionKeys(mrzInfo, reader);
        }

        private IBinary SelfIncrementedSSC
        {
            get { return _selfIncrementedSSC ?? (_selfIncrementedSSC = new SelfIncrementSSC(_sessionKeys.SSC())); }
        }

        public IBinary Transmit(IBinary rawCommandApdu)
        {
            return new Binary(
                        new DecryptedProtectedResponseApdu(
                               new Cached(
                                   new VerifiedProtectedResponseApdu(
                                         new Cached(
                                             new ExecutedCommandApdu(
                                                 new ProtectedCommandApdu(
                                                     rawCommandApdu,
                                                     _sessionKeys.KSenc(),
                                                     _sessionKeys.KSmac(),
                                                     new Cached(SelfIncrementedSSC.Bytes())
                                                 ),
                                                 _reader
                                             )
                                         ),
                                         new Cached(SelfIncrementedSSC.Bytes()),
                                         _sessionKeys.KSmac()
                                   )
                               ),
                               _sessionKeys.KSenc()
                          ).Bytes()
                    );
        }

        public void Dispose()
        {
            _reader.Dispose();
        }
    }
}
