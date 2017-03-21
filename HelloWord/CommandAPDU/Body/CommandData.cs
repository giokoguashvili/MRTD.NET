using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HelloWord.Cryptography;
using HelloWord.Infrastructure;

namespace HelloWord.CommandAPDU.Body
{
    public class CommandData : IBinary
    {
        private readonly IBinary _commandApduBody;

        public CommandData(IBinary commandApduBody)
        {
            _commandApduBody = commandApduBody;
        }
        public byte[] Bytes()
        {
            var commandDataLength = new Hex(
                                        new Lc(_commandApduBody)
                                    ).ToInt();
            return _commandApduBody
                .Bytes()
                .Skip(1)
                .Take(commandDataLength)
                .ToArray();
        }
    }
}
