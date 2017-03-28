using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HelloWord.DataGroups.FileIds;
using HelloWord.Infrastructure;
using PCSC;
using PCSC.Iso7816;

namespace HelloWord.Commands
{
    public class SelectApplicationCommandApdu : IBinary
    {
        private readonly IsoCase _isoCase = IsoCase.Case3Short;
        private readonly int _expectedDataLength = 0;
        private readonly SCardProtocol _activeProtocol = SCardProtocol.T1;
        private readonly IBinary _applicationIdentifier;

        public SelectApplicationCommandApdu(IBinary applicationIdentifier)
        {
            _applicationIdentifier = applicationIdentifier;
        }
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
