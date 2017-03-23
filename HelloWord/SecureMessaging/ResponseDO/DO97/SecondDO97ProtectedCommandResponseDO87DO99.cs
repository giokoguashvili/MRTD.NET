using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HelloWord.Infrastructure;

namespace HelloWord.SecureMessaging.ResponseDO.DO97
{
    public class SecondDO97ProtectedCommandResponseDO87DO99 : IBinary
    {
        private readonly IBinary _responseApdu;
        public SecondDO97ProtectedCommandResponseDO87DO99(IBinary responseApdu)
        {
            _responseApdu = responseApdu;
        }
        public byte[] Bytes()
        {
            return _responseApdu
                        .Bytes()
                        .Take(31)
                        .ToArray();
        }
    }
}
