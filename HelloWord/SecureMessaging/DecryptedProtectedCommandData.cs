using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HelloWord.Cryptography;
using HelloWord.Infrastructure;

namespace HelloWord.SecureMessaging
{
    public class DecryptedProtectedCommandData : IBinary
    {
        private readonly IBinary _do87;
        private readonly IBinary _kSenc;

        public DecryptedProtectedCommandData(
                IBinary do87,
                IBinary kSenc
            )
        {
            _do87 = do87;
            _kSenc = kSenc;
        }
        public byte[] Bytes()
        {
            return new TripleDES(
                    _kSenc,
                    _do87
                )
                .Decrypted()
                .Bytes();
        }
    }
}
