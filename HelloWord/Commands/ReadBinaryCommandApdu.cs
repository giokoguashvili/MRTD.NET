using System.Linq;
using HelloWord.Infrastructure;
using HelloWord.ISO7816.CommandAPDU;
using PCSC;
using PCSC.Iso7816;

namespace HelloWord.Commands
{
    public class ReadBinaryCommandApdu : IBinary
    {
        private readonly IsoCase _isoCase = IsoCase.Case2Short;
        private readonly int _offsetLength;
        private readonly int _expectedDataLength;
        private readonly SCardProtocol _activeProtocol = SCardProtocol.T1;

        public ReadBinaryCommandApdu(int expectedDataLength) : this(0, expectedDataLength)
        {
        }
        public ReadBinaryCommandApdu(int offsetLength, int expectedDataLength)
        {
            _offsetLength = offsetLength;
            _expectedDataLength = expectedDataLength;
        }

        public byte[] Bytes()
        {
            var offsetMSB = new HexInt(_offsetLength).Bytes().First();
            var offsetLSB = new HexInt(_offsetLength + _expectedDataLength).Bytes().First();
            return new CommandApdu(this._isoCase, this._activeProtocol)
            {
                CLA = 0x00,
                Instruction = InstructionCode.ReadBinary,
                P1 = 0x00,
                P2 = offsetMSB, //new BinaryHex(_offsetLength.ToString("X2")).Bytes().First(),
                Le = _expectedDataLength
            }.ToArray();
        }
    }
}
