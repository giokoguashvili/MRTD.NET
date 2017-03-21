using HelloWord.CommandAPDU;
using HelloWord.Infrastructure;
using PCSC;
using PCSC.Iso7816;

namespace HelloWord.Commands
{
    public class ExternalAuthenticateCommand : ICommandAPDU
    {
        private readonly IBinary _commandData;
        private readonly IsoCase _isoCase = PCSC.Iso7816.IsoCase.Case4Short;
        private readonly int _exceptedDataLength = 40; // (0x28)
        private readonly SCardProtocol _activeProtocol = SCardProtocol.T1;

        public ExternalAuthenticateCommand(IBinary commandData) 
        {
            this._commandData = commandData;
        }

        public byte[] Bytes()
        {
            return new CommandApdu(this._isoCase, this._activeProtocol)
            {
                CLA = 0x00,
                Instruction = InstructionCode.ExternalAuthenticate,
                P1 = 0x00,
                P2 = 0x00,
                Data = _commandData.Bytes(),
                Le = this._exceptedDataLength, 
            }.ToArray();
        }

        public int ExceptedDataLength()
        {
            return this._exceptedDataLength;
        }

        public IsoCase Case()
        {
            return this._isoCase;
        }

        public SCardProtocol Protocol()
        {
            return this._activeProtocol;
        }
    }
}
