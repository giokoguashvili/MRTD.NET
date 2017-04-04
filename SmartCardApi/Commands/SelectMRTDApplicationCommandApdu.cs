using PCSC;
using PCSC.Iso7816;
using SmartCardApi.Infrastructure;

namespace SmartCardApi.Commands
{
    public class SelectMRTDApplicationCommandApdu : IBinary
    {
        private readonly IsoCase _isoCase = IsoCase.Case3Short;
        private readonly int _expectedDataLength = 0;
        private readonly SCardProtocol _activeProtocol = SCardProtocol.T1;
        private readonly IBinary _applicationIdentifier = new BinaryHex("A0000002471001");
        public byte[] Bytes()
        {
            return new CommandApdu(_isoCase, _activeProtocol)
            {
                CLA = 0x00,
                Instruction = InstructionCode.SelectFile,
                P1 = 0x04,
                P2 = 0x0C,
                Data = _applicationIdentifier.Bytes()
            }.ToArray();
        }
    }
}
