using PCSC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HelloWord
{
    public class SCardStatusResponse
    {
        private readonly SCardError _sCardError;
        private readonly SCardProtocol _sCardProtocol;
        private readonly SCardState _sCardState;
        public SCardStatusResponse(
            SCardError sCardError,
            SCardProtocol sCardProtocol,
            SCardState sCardState)
        {
            this._sCardError = sCardError;
            this._sCardProtocol = sCardProtocol;
            this._sCardState = sCardState;
        }
        public bool Success()
        {
            return this._sCardError == SCardError.Success;
        }


    }
}
