using SmartCardApi.Cryptography;
using SmartCardApi.Infrastructure;

namespace SmartCardApi.SecureMessaging
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
