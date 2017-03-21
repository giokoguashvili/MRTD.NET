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
        private readonly IBinary _padedCommandApduData;

        public EncryptedCommandApduData(
            IBinary kSenc,
            IBinary padedCommandApduData)
        {
            _kSenc = kSenc;
            _padedCommandApduData = padedCommandApduData;
        }
        public byte[] Bytes()
        {
            return new TripleDES(_kSenc, _padedCommandApduData)
                .Encrypted()
                .Bytes();
        }
    }
}
