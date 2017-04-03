using System;
using HelloWord.ISO7816.CommandAPDU;
using HelloWord.SmartCard;
using PCSC;
using PCSC.Iso7816;

namespace HelloWord.Infrastructure
{
    public class ExecutedCommandApdu : IBinary
    {
        private readonly IBinary _rawCommandApdu;
        private readonly IReader _reader;
        public ExecutedCommandApdu(
                IBinary rawCommandApdu,
                IReader reader
            )
        {
            _rawCommandApdu = rawCommandApdu;
            _reader = reader;
        }

        public byte[] Bytes()
        {
            return _reader
                        .Transmit(_rawCommandApdu)
                        .Bytes();
        }
    }
}
