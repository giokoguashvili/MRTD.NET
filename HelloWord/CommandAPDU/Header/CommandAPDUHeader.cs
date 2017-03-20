using System.Linq;
using HelloWord.Infrastructure;

namespace HelloWord.CommandAPDU.Header
{
    public class CommandAPDUHeader : IBinary
    {
        private readonly IBinary _rawCommandApdu;

        public CommandAPDUHeader(IBinary rawCommandAPDU)
        {
            _rawCommandApdu = rawCommandAPDU;
        }
        public byte[] Bytes()
        {
            return _rawCommandApdu
                .Bytes()
                .Take(4)
                .ToArray();
        }
    }
}
