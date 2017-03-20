using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HelloWord.Infrastructure;

namespace HelloWord.CommandAPDU
{
    public class P1 : IBinary
    {
        private readonly IBinary _commandApduHeader;

        public P1(IBinary commandApduHeader)
        {
            _commandApduHeader = commandApduHeader;
        }
        public byte[] Bytes()
        {
            return _commandApduHeader
                .Bytes()
                .Skip(2)
                .Take(1)
                .ToArray();
        }
    }
}
