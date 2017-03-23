using System.Linq;
using HelloWord.Infrastructure;

namespace HelloWord.SecureMessaging.ResponseDO.DO87
{
    public class DO87ProtectedCommandResponseDO99 : IBinary
    {
        private readonly IBinary _responseApdu;

        public DO87ProtectedCommandResponseDO99(IBinary responseApdu)
        {
            _responseApdu = responseApdu;
        }
        public byte[] Bytes()
        {
            return _responseApdu
                .Bytes()
                .Take(4)
                .ToArray();
        }
    }
}
