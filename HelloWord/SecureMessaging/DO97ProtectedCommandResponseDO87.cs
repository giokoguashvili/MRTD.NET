using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HelloWord.Infrastructure;

namespace HelloWord.SecureMessaging
{
    public class DO97ProtectedCommandResponseDO87 : IBinary
    {
        private readonly IBinary _responseApdu;

        public DO97ProtectedCommandResponseDO87(IBinary responseApdu)
        {
            _responseApdu = responseApdu;
        }
        public byte[] Bytes()
        {
            return _responseApdu
                .Bytes()
                .Skip(8)
                .Take(8)
                .ToArray();
        }
    }
}
