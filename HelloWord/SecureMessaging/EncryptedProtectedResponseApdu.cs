using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HelloWord.Cryptography;
using HelloWord.Infrastructure;
using HelloWord.SecureMessaging.DataObjects.Extracted;

namespace HelloWord.SecureMessaging
{
    public class DecryptedProtectedResponseApdu : IBinary
    {
        private readonly IBinary _protectedResponseApdu;
        private readonly IBinary _kSenc;

        public DecryptedProtectedResponseApdu(
                IBinary protectedResponseApdu,
                IBinary kSenc
            )
        {
            _protectedResponseApdu = protectedResponseApdu;
            _kSenc = kSenc;
        }
        public byte[] Bytes()
        {
            var des = new TripleDES(
                    _kSenc,
                    new ExtractedDO87(_protectedResponseApdu)
                        .EncryptedData()
                ).Decrypted()
                .Bytes();

            return des;
        }
    }
}
