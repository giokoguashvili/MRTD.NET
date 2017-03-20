using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HelloWord.Infrastructure;

namespace HelloWord.CommandAPDU.Body
{
    public class CommandAPDUBody : IBinary
    {
        private readonly IBinary _rawCommandApdu;

        public CommandAPDUBody(IBinary rawCommandAPDU)
        {
            _rawCommandApdu = rawCommandAPDU;
        }
        public byte[] Bytes()
        {
            return _rawCommandApdu
                .Bytes()
                .Skip(4)
                .ToArray();
        }
    }
}
