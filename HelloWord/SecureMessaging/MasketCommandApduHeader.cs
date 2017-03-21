using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HelloWord.CommandAPDU.Header;
using HelloWord.Infrastructure;

namespace HelloWord.SecureMessaging
{
    public class MaskedCommandApduHeader : IBinary
    {
        private readonly IBinary _commandApduHeader;

        public MaskedCommandApduHeader(IBinary commandApduHeader)
        {
            _commandApduHeader = commandApduHeader;
        }
        public byte[] Bytes()
        {
            return new MaskedCLA(
                    new CLA(_commandApduHeader)
                )
                .Bytes()
                .Concat(_commandApduHeader.Bytes().Skip(1))
                .ToArray();
        }
    }
}
