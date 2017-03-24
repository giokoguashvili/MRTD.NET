using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HelloWord.Cryptography;
using HelloWord.Infrastructure;
using HelloWord.ISO7816.CommandAPDU.Body;

namespace HelloWord.SecureMessaging.DO
{
    public class UnprotectedCommandDO87 : IDO
    {
        private readonly IBinary _kSenc;
        private readonly IBinary _unprotectedCommandApdu;
        public UnprotectedCommandDO87(
                IBinary kSenc,
                IBinary unprotectedCommandApdu
            )
        {
            _kSenc = kSenc;
            _unprotectedCommandApdu = unprotectedCommandApdu;
        }

        public byte[] Bytes()
        {
            return new BuildedDO87(
                    _EncryptedData()
                ).Bytes();
        }

        public IBinary EncryptedData()
        {
            return _EncryptedData();
        }

        public IBinary DecryptedData()
        {
            return new PaddedData(
                     new CommandApduData(
                         new CommandApduBody(_unprotectedCommandApdu)
                     )
                 );
        }

        private IBinary _EncryptedData()
        {
            return new TripleDES(
                    _kSenc,
                    new PaddedData(
                        new CommandApduData(
                            new CommandApduBody(_unprotectedCommandApdu)
                        )
                    )
                ).Encrypted();
        }
    }
}
