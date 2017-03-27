using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HelloWord.Infrastructure;
using HelloWord.SecureMessaging.ResponseDO.DO97;

namespace HelloWord.SecureMessaging.DO
{
    public class DO87 : IDO , IBinary
    {
        private readonly IBinary _kSenc;
        private readonly IBinary _unprotectedCommandApdu;
        private readonly IBinary _protectedResponseApdu;

        public DO87(
                IBinary _kSenc,
                IBinary unprotectedCommandApdu
            ) : this(_kSenc, unprotectedCommandApdu, new Binary())
        { }

        private DO87(
                IBinary _kSenc,
                IBinary unprotectedCommandApdu,
                IBinary protectedResponseApdu
            )
        {
            this._kSenc = _kSenc;
            _unprotectedCommandApdu = unprotectedCommandApdu;
            _protectedResponseApdu = protectedResponseApdu;
        }

        public byte[] Bytes()
        {
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
