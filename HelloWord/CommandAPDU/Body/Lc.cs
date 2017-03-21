using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HelloWord.Infrastructure;

namespace HelloWord.CommandAPDU.Body
{
    public class Lc : IBinary
    {
        private readonly IBinary _commandApduBody;

        public Lc(IBinary commandAPDUBody)
        {
            _commandApduBody = commandAPDUBody;
        }
        public byte[] Bytes()
        {
            return _commandApduBody
                .Bytes()
                .Take(1)
                .ToArray();
        }
    }
}
