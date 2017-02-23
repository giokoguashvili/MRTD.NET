using PCSC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HelloWord
{
    public class CardReader
    {
        private readonly ISCardReader _sCardReader;
        public CardReader(ISCardReader sCardReader)
        {
            this._sCardReader = sCardReader;
        }

        public SCardStatusResponse Status()
        {
            return null; // new SCardStatusResponse();
        }
    }
}
