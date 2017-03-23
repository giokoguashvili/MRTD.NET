using System.Linq;
using HelloWord.Infrastructure;

namespace HelloWord.SecureMessaging.ResponseDO.DO97
{
    public class DO97ProtectedCommandResponseDO8E : IBinary
    {
        private readonly IBinary _responseApdu;

        public DO97ProtectedCommandResponseDO8E(IBinary responseApdu)
        {
            _responseApdu = responseApdu;
        }
        public byte[] Bytes()
        {
            return _responseApdu
                .Bytes()
                .Skip(17)
                .Take(8)
                .ToArray();
        }
    }
}
