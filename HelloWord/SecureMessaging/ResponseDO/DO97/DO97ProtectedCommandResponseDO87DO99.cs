using System.Linq;
using HelloWord.Infrastructure;

namespace HelloWord.SecureMessaging.ResponseDO.DO97
{
    public class DO97ProtectedCommandResponseDO87DO99 : IBinary
    {
        private readonly IBinary _responseApdu;

        public DO97ProtectedCommandResponseDO87DO99(IBinary responseApdu)
        {
            _responseApdu = responseApdu;
        }
        public byte[] Bytes()
        {
            return _responseApdu
                .Bytes()
                .Take(15)
                .ToArray();
        }
    }
}
