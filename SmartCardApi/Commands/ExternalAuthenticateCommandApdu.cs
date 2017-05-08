using PCSC;
using PCSC.Iso7816;
using SmartCardApi.Infrastructure;
using SmartCardApi.Infrastructure.Interfaces;

namespace SmartCardApi.Commands
{
    public class ExternalAuthenticateCommandApdu : IBinary
    {
        private readonly IBinary _commandData;
        private readonly IsoCase _isoCase = IsoCase.Case4Short;
        private readonly int _exceptedDataLength = 40; // (0x28)
        private readonly SCardProtocol _activeProtocol = SCardProtocol.T1;

        public ExternalAuthenticateCommandApdu(IBinary commandData) 
        {
            _commandData = commandData;
        }

        public byte[] Bytes()
        {
            return new CommandApdu(_isoCase, _activeProtocol)
            {
                CLA = 0x00,
                Instruction = InstructionCode.ExternalAuthenticate,
                P1 = 0x00,
                P2 = 0x00,
                Data = _commandData.Bytes(),
                Le = _exceptedDataLength, 
            }.ToArray();
        }
    }
}
