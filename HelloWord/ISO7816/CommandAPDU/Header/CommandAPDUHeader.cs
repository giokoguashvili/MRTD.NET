using System.Linq;
using HelloWord.Infrastructure;

namespace HelloWord.ISO7816.CommandAPDU.Header
{
    public class CommandApduHeader : IBinary
    {
        private readonly IBinary _rawCommandApdu;

        public CommandApduHeader(IBinary rawCommandApdu)
        {
            _rawCommandApdu = rawCommandApdu;
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
