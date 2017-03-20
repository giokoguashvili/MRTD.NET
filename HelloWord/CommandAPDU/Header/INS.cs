using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HelloWord.Infrastructure
{
    public class INS : IBinary
    {
        private readonly IBinary _commandApduHeader;

        public INS(IBinary commandApduHeader)
        {
            _commandApduHeader = commandApduHeader;
        }

        public byte[] Bytes()
        {
            return _commandApduHeader
                .Bytes()
                .Skip(1)
                .Take(1)
                .ToArray();
        }
    }
}
