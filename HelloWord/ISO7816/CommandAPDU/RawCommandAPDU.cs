using HelloWord.Infrastructure;

namespace HelloWord.ISO7816.CommandAPDU
{
    public class RawCommandApdu : IBinary
    {
        private readonly string _commandApdu;

        public RawCommandApdu(string commandApdu)
        {
            _commandApdu = commandApdu;
        }
        public byte[] Bytes()
        {
            return new BinaryHex(_commandApdu).Bytes();
        }
    }
}
