using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HelloWord.Infrastructure
{
    public class CommandAPDUHeader : IBinary
    {
        private readonly IBinary _rawCommandApdu;

        public CommandAPDUHeader(IBinary rawCommandAPDU)
        {
            _rawCommandApdu = rawCommandAPDU;
        }
        public byte[] Bytes()
        {
            return _rawCommandApdu
                .Bytes()
                .Take(4)
                .ToArray();
        }
    }
}
