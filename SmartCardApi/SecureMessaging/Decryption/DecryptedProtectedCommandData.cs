using SmartCardApi.Cryptography;
using SmartCardApi.Infrastructure;
using SmartCardApi.Infrastructure.Interfaces;

namespace SmartCardApi.SecureMessaging.Decryption
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
