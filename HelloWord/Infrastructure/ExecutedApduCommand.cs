using HelloWord.SmartCard;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HelloWord.Cryptography;
using HelloWord.APDU;
using PCSC;
using PCSC.Iso7816;

namespace HelloWord.ApduCommands
{
    public class ExecutedCommandAPDU : ICommandAPDU
    {
        private readonly ICommandAPDU _commandAPDU;
        private readonly ISCardReader _reader;
        private readonly int _responseApduTrailerLength = 2; // 0x02
        public ExecutedCommandAPDU(
                ICommandAPDU commandAPDU,
                ISCardReader reader
            )
        {
            this._commandAPDU = commandAPDU;
            this._reader = reader;
        }

        public byte[] Bytes()
        {
            var receiveBuffer = new byte[this._commandAPDU.DataLength() + _responseApduTrailerLength];

            var receivePci = new SCardPCI();
            var sendPci = SCardPCI.GetPci(this._reader.ActiveProtocol);

            var sc = this._reader.Transmit(
                        sendPci,
                        this._commandAPDU.Bytes(),
                        receivePci,
                        ref receiveBuffer);

            if (sc != SCardError.Success)
            {
                throw new Exception("Error: " + SCardHelper.StringifyError(sc));
            }

            return receiveBuffer;
        }


        public SCardProtocol ActiveProtocol()
        {
            return this._commandAPDU.ActiveProtocol();
        }

        public int DataLength()
        {
            return this._commandAPDU.DataLength();
        }

        public IsoCase IsoCase()
        {
            return this._commandAPDU.IsoCase();
        }
    }
}
