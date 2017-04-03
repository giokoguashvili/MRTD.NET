using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HelloWord.Commands;
using HelloWord.Cryptography;
using HelloWord.Cryptography.RandomKeys;
using HelloWord.Infrastructure;
using HelloWord.ISO7816.ResponseAPDU.Body;
using HelloWord.SecureMessaging;
using PCSC;

namespace HelloWord.SmartCard
{
    public class SecuredReader : IReader
    {
        private readonly IReader _reader;
        private readonly ISessionKeys _sessionKeys;
        private IBinary _selfIncrementedSSC;
        public SecuredReader(
                string mrzInfo,
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
            return new DecryptedProtectedResponseApdu(
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
                  );
        }
    }
}
