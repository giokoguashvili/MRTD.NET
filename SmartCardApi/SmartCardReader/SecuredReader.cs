using System;
using SmartCardApi.Infrastructure;
using SmartCardApi.Infrastructure.Interfaces;
using SmartCardApi.SecureMessaging;
using SmartCardApi.SecureMessaging.Decryption;
using SmartCardApi.SmartCard;

namespace SmartCardApi.SmartCardReader
{
    public class SecuredReader : IReader
    {
        private readonly IReader _reader;
        private readonly ISessionKeys _sessionKeys;
        private readonly IState<IBinary> _selfIncrementedSsc;
        public SecuredReader(
                ISymbols mrzInfo,
                IReader reader
            )
        {
           
            _reader = reader;
            _sessionKeys = new SessionKeys(mrzInfo, reader);
            _selfIncrementedSsc = new SelfIncrementSSC(_sessionKeys.SSC());
        }

        public IBinary Transmit(IBinary rawCommandApdu)
        {
            //return
            //    new Cached(
            //        new ExecutedCommandApdu(
            //            rawCommandApdu,
            //            _reader
            //        )
            //    );

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
                                                     _selfIncrementedSsc.Next()
                                                 ),
                                                 _reader
                                             )
                                         ),
                                         _selfIncrementedSsc.Next(),
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
