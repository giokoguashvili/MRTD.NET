using HelloWord.Cryptography;
using PCSC;
using PCSC.Iso7816;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HelloWord.Infrastructure;

namespace HelloWord.CommandAPDU
{
    public class GetChallengeCommand : ICommandAPDU
    {
        private readonly IsoCase _isoCase = IsoCase.Case2Short;
        private readonly int _expectedDataLength = 8;
        private readonly SCardProtocol _activeProtocol = SCardProtocol.T1;
        private readonly IBinary _applicationIdentifier = new BinaryHex("011E"); // 0x01 0x1E
        public byte[] Bytes()
        {
            return new CommandApdu(this._isoCase, this._activeProtocol)
            {
                CLA = 0x00,
                Instruction = InstructionCode.GetChallenge,
                P1 = 0x00,
                P2 = 0x00,
                Le = 8,
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

        public SCardProtocol Protocol()
        {
            return this._activeProtocol;
        }
    }
}
