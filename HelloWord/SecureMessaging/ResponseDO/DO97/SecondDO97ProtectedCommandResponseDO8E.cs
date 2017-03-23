using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HelloWord.Infrastructure;

namespace HelloWord.SecureMessaging.ResponseDO.DO97
{
    public class SecondDO97ProtectedCommandResponseDO8E : IBinary
    {
        private readonly IBinary _responseApdu;

        public SecondDO97ProtectedCommandResponseDO8E(IBinary responseApdu)
        {
            _responseApdu = responseApdu;
        }
        public byte[] Bytes()
        {
            return _responseApdu
                .Bytes()
                .Skip(33)
                .Take(8)
                .ToArray();
        }
    }
}
