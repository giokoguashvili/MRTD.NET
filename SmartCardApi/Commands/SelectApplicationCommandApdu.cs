using PCSC;
using PCSC.Iso7816;
using SmartCardApi.Infrastructure;
using SmartCardApi.Infrastructure.Interfaces;

namespace SmartCardApi.Commands
{
    public class SelectApplicationCommandApdu : IBinary
    {
        private readonly IBinary _fid;
        private readonly IsoCase _isoCase = IsoCase.Case3Short;
        private readonly int _expectedDataLength = 0;
        private readonly SCardProtocol _activeProtocol = SCardProtocol.T1;

        public SelectApplicationCommandApdu(IBinary fid)
        {
            _fid = fid;
        }
        public byte[] Bytes()
        {
            return new CommandApdu(_isoCase, _activeProtocol)
            {
                CLA = 0x00,
                Instruction = InstructionCode.SelectFile,
                P1 = 0x02,
                P2 = 0x0C,
                Data = _fid.Bytes()
            }.ToArray();
        }
    }
}
