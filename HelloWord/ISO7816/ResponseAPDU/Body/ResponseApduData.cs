using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HelloWord.Infrastructure;

namespace HelloWord.ISO7816.ResponseAPDU.Body
{
    public class ResponseApduData : IBinary
    {
        private readonly IBinary _executedCommandApdu;
        private readonly int _responseApduTrailerLength = 2; // len(SW1) + len(SW2) = 2 bytes

        public ResponseApduData(IBinary executedCommandApdu)
        {
            _executedCommandApdu = executedCommandApdu;
        }

        public byte[] Bytes()
        {
            return _executedCommandApdu
                .Bytes()
                .Reverse()
                .Skip(_responseApduTrailerLength)
                .Reverse()
                .ToArray();
        }
    }
}
