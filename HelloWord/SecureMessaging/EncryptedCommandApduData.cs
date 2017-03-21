using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HelloWord.Cryptography;
using HelloWord.Infrastructure;

namespace HelloWord.SecureMessaging
{
    public class EncryptedCommandApduData : IBinary
    {
        private readonly IBinary _kSenc;
        private readonly IBinary _dataForEncrypt;

        public EncryptedCommandApduData(
            IBinary kSenc,
            IBinary dataForEncrypt)
        {
            _kSenc = kSenc;
            _dataForEncrypt = dataForEncrypt;
        }
        public byte[] Bytes()
        {
            return new TripleDES(_kSenc, _dataForEncrypt)
                .Encrypted()
                .Bytes();
        }
    }
}
