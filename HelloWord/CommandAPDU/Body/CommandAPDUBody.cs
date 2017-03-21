using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HelloWord.Infrastructure;

namespace HelloWord.CommandAPDU.Body
{
    public class CommandApduBody : IBinary
    {
        private readonly IBinary _rawCommandApdu;

        public CommandApduBody(IBinary rawCommandApdu)
        {
            _rawCommandApdu = rawCommandApdu;
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
