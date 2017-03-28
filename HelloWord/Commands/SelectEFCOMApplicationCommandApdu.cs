using HelloWord.Infrastructure;
using PCSC;
using PCSC.Iso7816;

namespace HelloWord.Commands
{
    public class SelectEFCOMApplicationCommandApdu : IBinary
    {
        private readonly IsoCase _isoCase = IsoCase.Case3Short;
        private readonly int _expectedDataLength = 0;
        private readonly SCardProtocol _activeProtocol = SCardProtocol.T1;
        private readonly IBinary _applicationIdentifier = new BinaryHex("011E");
        public byte[] Bytes()
        {
            return new CommandApdu(this._isoCase, this._activeProtocol)
            {
                CLA = 0x00,
                Instruction = InstructionCode.SelectFile,
                P1 = 0x02,
                P2 = 0x0C,
                Data = this._applicationIdentifier.Bytes()
            }.ToArray();
        }
    }
}
