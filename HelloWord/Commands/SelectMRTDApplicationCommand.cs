using HelloWord.Cryptography;
using HelloWord.Infrastructure;
using HelloWord.ISO7816.CommandAPDU;
using PCSC;
using PCSC.Iso7816;

namespace HelloWord.Commands
{
    public class SelectMRTDApplicationCommand : ICommandApdu
    {
        private readonly IsoCase _isoCase = IsoCase.Case3Short;
        private readonly int _expectedDataLength = 0;
        private readonly SCardProtocol _activeProtocol = SCardProtocol.T1;
        private readonly IBinary _applicationIdentifier = new BinaryHex("A0000002471001");
        public byte[] Bytes()
        {
            return new CommandApdu(this._isoCase, this._activeProtocol)
            {
                CLA = 0x00,
                Instruction = InstructionCode.SelectFile,
                P1 = 0x04,
                P2 = 0x0C,
                Data = _applicationIdentifier.Bytes()
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
