using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HelloWord.Infrastructure;

namespace HelloWord.CommandAPDU.Body
{
    public class Data : IBinary
    {
        private readonly IBinary _commandApduBody;

        public Data(IBinary commandApduBody)
        {
            _commandApduBody = commandApduBody;
        }
        public byte[] Bytes()
        {
            var commandDataLength = BitConverter.ToInt32(new Lc(_commandApduBody).Bytes(), 0);
            return _commandApduBody
                .Bytes()
                .Skip(1)
                .Take(commandDataLength)
                .ToArray();
        }
    }
}
