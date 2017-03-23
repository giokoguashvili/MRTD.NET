using HelloWord.Infrastructure;
using HelloWord.ISO7816.CommandAPDU;
using PCSC;
using PCSC.Iso7816;

namespace HelloWord.Commands
{
    public class ReadBinaryCommand : IBinary
    {
        private readonly IsoCase _isoCase = IsoCase.Case2Short;
        private readonly byte _p2;
        private readonly int _expectedDataLength;
        private readonly SCardProtocol _activeProtocol = SCardProtocol.T1;

        public ReadBinaryCommand(int expectedDataLength) : this(0x00, expectedDataLength)
        {
        }
        public ReadBinaryCommand(byte p2, int expectedDataLength)
        {
            _p2 = p2;
            _expectedDataLength = expectedDataLength;
        }

        public byte[] Bytes()
        {
            return new CommandApdu(this._isoCase, this._activeProtocol)
            {
                CLA = 0x00,
                Instruction = InstructionCode.ReadBinary,
                P1 = 0x00,
                P2 = _p2,
                Le = this._expectedDataLength
            }.ToArray();
        }
    }
}
