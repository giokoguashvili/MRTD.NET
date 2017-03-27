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
            throw new NotImplementedException();
            //return new BuildedDO87(
            //        _EncryptedData()
            //    ).Bytes();
        }

        public IBinary EncryptedData()
        {
            return _EncryptedData();
        }

        public IBinary DecryptedData()
        {
            return new Padded(
                     new CommandApduData(
                         new CommandApduBody(_unprotectedCommandApdu)
                     )
                 );
        }

        private IBinary _EncryptedData()
        {
            var commandApduData = new CommandApduData(
                                        new CommandApduBody(_unprotectedCommandApdu)
                                    );

            if (commandApduData.Bytes().Length == 0)
            {
                return new Binary();
            }
            else
            {
                return new TripleDES(
                        _kSenc,
                        new Padded(
                            new CommandApduData(
                                new CommandApduBody(_unprotectedCommandApdu)
                            )
                        )
                    ).Encrypted();
            }
        }
    }
}
