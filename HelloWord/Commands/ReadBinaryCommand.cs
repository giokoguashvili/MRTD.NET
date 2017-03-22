using HelloWord.ISO7816.CommandAPDU;
using PCSC;
using PCSC.Iso7816;

namespace HelloWord.Commands
{
    public class ReadBinaryCommand : ICommandApdu
    {
        private readonly IsoCase _isoCase = IsoCase.Case2Short;
        private readonly int _expectedDataLength;
        private readonly SCardProtocol _activeProtocol = SCardProtocol.T1;

        public ReadBinaryCommand(int expectedDataLength)
        {
            _expectedDataLength = expectedDataLength;
        }
        public byte[] Bytes()
        {
            return new CommandApdu(this._isoCase, this._activeProtocol)
            {
                CLA = 0x00,
                Instruction = InstructionCode.ReadBinary,
                P1 = 0x00,
                P2 = 0x00,
                Le = this._expectedDataLength
            }.ToArray();
        }

        public int ExceptedDataLength()
        {
            return this._expectedDataLength;
        }

        public IsoCase Case()
        {
            return this._isoCase;
        }

        public SCardProtocol ActiveProtocol()
        {
            return this._activeProtocol;
        }
    }
}
