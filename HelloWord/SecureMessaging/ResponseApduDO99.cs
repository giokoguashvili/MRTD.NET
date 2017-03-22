using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HelloWord.Infrastructure;

namespace HelloWord.SecureMessaging
{
    public class ResponseApduDO99 : IBinary
    {
        private readonly IBinary _responseApdu;

        public ResponseApduDO99(IBinary responseApdu)
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
