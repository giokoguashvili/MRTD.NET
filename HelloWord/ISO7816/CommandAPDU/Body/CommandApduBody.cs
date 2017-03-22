using System.Linq;
using HelloWord.Infrastructure;

namespace HelloWord.ISO7816.CommandAPDU.Body
{
    public class CommandApduBody : IBinary
    {
        private readonly IBinary _rawCommandApdu;

        public CommandApduBody(IBinary rawCommandApdu)
        {
            _rawCommandApdu = rawCommandApdu;
        }
        public byte[] Bytes()
        {
            return _rawCommandApdu
                .Bytes()
                .Skip(4)
                .ToArray();
        }
    }
}
