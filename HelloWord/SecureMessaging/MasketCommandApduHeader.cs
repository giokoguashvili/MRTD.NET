using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HelloWord.Infrastructure;
using HelloWord.ISO7816.CommandAPDU.Header;

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
            return new ConcatenatedBinaries(
                new MaskedCLA(
                    new CLA(_commandApduHeader)
                ),
                new Binary(
                    _commandApduHeader
                        .Bytes()
                        .Skip(1)
                )
            ).Bytes();
        }
    }
}
