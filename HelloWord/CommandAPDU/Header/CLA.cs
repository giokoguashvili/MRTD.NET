using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HelloWord.Infrastructure
{
    public class CLA : IBinary
    {
        private readonly IBinary _commandApduHeader;
        public CLA(IBinary commandApduHeader)
        {
            _commandApduHeader = commandApduHeader;
        }
        public byte[] Bytes()
        {
            return _commandApduHeader
                .Bytes()
                .Take(1)
                .ToArray();
        }
    }
}
