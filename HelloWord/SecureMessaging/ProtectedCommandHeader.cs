using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HelloWord.CommandAPDU;
using HelloWord.Infrastructure;

namespace HelloWord.SecureMessaging
{
    public class ProtectedCommandHeader : IBinary
    {
        private readonly ICommandAPDUHeader _commandHeader;

        public ProtectedCommandHeader(ICommandAPDUHeader commandHeader)
        {
            _commandHeader = commandHeader;
        }
        public byte[] Bytes()
        {
            return
                new PadedCommandHeader(
                        _commandHeader
                            .WithCLA(new MaskedCLA(_commandHeader.CLA()))
                 ).Bytes();
        }
    }
}
