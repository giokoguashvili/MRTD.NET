using HelloWord.Cryptography;
using HelloWord.Infrastructure;
using HelloWord.ISO7816.CommandAPDU;
using PCSC;
using PCSC.Iso7816;

namespace HelloWord.Commands
{
    public class GetChallengeCommandApdu : IBinary
    {
        private readonly IsoCase _isoCase = IsoCase.Case2Short;
        private readonly int _expectedDataLength = 8;
        private readonly SCardProtocol _activeProtocol = SCardProtocol.T1;
        public byte[] Bytes()
        {
            return new CommandApdu(_isoCase, _activeProtocol)
            {
                CLA = 0x00,
                Instruction = InstructionCode.GetChallenge,
                P1 = 0x00,
                P2 = 0x00,
                Le = 8,
            }.ToArray();
        }
    }
}
