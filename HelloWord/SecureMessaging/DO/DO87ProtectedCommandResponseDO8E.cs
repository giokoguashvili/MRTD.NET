using System.Linq;
using HelloWord.Infrastructure;

namespace HelloWord.SecureMessaging.DO
{
    public class DO87ProtectedCommandResponseDO8E : IBinary
    {
        private readonly IBinary _responseApdu;

        public DO87ProtectedCommandResponseDO8E(IBinary responseApdu)
        {
            _responseApdu = responseApdu;
        }
        public byte[] Bytes()
        {
            return _responseApdu
                .Bytes()
                .Skip(6)
                .Take(8)
                .ToArray();
        }
    }
}
