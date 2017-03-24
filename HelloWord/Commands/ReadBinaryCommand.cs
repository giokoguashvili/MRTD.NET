using System.Linq;
using HelloWord.Infrastructure;
using HelloWord.ISO7816.CommandAPDU;
using PCSC;
using PCSC.Iso7816;

namespace HelloWord.Commands
{
    public class ReadBinaryCommand : IBinary
    {
        private readonly IsoCase _isoCase = IsoCase.Case2Short;
        private readonly int _offsetLength;
        private readonly int _expectedDataLength;
        private readonly SCardProtocol _activeProtocol = SCardProtocol.T1;

        public ReadBinaryCommand(int expectedDataLength) : this(0, expectedDataLength)
        {
        }
        public ReadBinaryCommand(int offsetLength, int expectedDataLength)
        {
            _offsetLength = offsetLength;
            _expectedDataLength = expectedDataLength;
        }

        public byte[] Bytes()
        {
            return new CommandApdu(this._isoCase, this._activeProtocol)
            {
                CLA = 0x00,
                Instruction = InstructionCode.ReadBinary,
                P1 = 0x00,
                P2 = new BinaryHex(_offsetLength.ToString("X2")).Bytes().First(),
                Le = this._expectedDataLength
            }.ToArray();
        }
    }
}
