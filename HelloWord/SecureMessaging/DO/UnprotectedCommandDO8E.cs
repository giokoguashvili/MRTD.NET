using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HelloWord.Cryptography;
using HelloWord.Infrastructure;
using HelloWord.ISO7816.CommandAPDU.Header;

namespace HelloWord.SecureMessaging.DO
{
    public class UnprotectedCommandDO8E : IDO
    {
        private readonly IBinary _kSenc;
        private readonly IBinary _kSmac;
        private readonly IBinary _unprotectedCommandApdu;
        private readonly IBinary _incrementedSsc;

        public UnprotectedCommandDO8E(
                IBinary kSenc,
                IBinary kSmac,
                IBinary unprotectedCommandApdu,
                IBinary incrementedSsc
            )
        {
            _kSenc = kSenc;
            _kSmac = kSmac;
            _unprotectedCommandApdu = unprotectedCommandApdu;
            _incrementedSsc = incrementedSsc;
        }

        public byte[] Bytes()
        {
            //new CC(
            //    new N(
            //        _incrementedSsc,
            //        new M(
            //            new Padded(
            //                new CommandApduHeader(_unprotectedCommandApdu)
            //            ), 
            //            new ConcatenatedBinaries(
            //                new DO87(_kSenc)
            //                    .FromUnprotectedCommandApdu(_unprotectedCommandApdu)
            //                    .EncryptedData(),
            //                new BuildedDO97(_unprotectedCommandApdu)
            //            )
            //        )
            //    ),
            //    _kSmac
            //)

            throw new NotImplementedException();
        }

        public IBinary EncryptedData()
        {
            throw new NotImplementedException();
        }

        public IBinary DecryptedData()
        {
            throw new NotImplementedException();
        }
    }
}
