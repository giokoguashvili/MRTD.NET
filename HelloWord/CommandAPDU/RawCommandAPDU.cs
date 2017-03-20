using HelloWord.Cryptography;
using HelloWord.Infrastructure;

namespace HelloWord.CommandAPDU
{
    public class RawCommandAPDU : IBinary
    {
        private readonly string _commandApdu;

        public RawCommandAPDU(string commandAPDU)
        {
            _commandApdu = commandAPDU;
        }
        public byte[] Bytes()
        {
            return new BinaryHex(_commandApdu).Bytes();
        }
    }
}
