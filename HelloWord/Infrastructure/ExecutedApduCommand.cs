using System;
using HelloWord.CommandAPDU;
using HelloWord.SmartCard;
using PCSC;
using PCSC.Iso7816;

namespace HelloWord.Infrastructure
{
    public class ExecutedCommandAPDU : ICommandAPDU
    {
        private readonly ICommandAPDU _commandApdu;
        private readonly IReader _reader;
        private readonly int _responseApduTrailerLength = 2; // 0x02
        public ExecutedCommandAPDU(
                ICommandAPDU commandApdu,
                IReader reader
            )
        {
            this._commandApdu = commandApdu;
            this._reader = reader;
        }

        public byte[] Bytes()
        {
            var receiveBuffer = new byte[this._commandApdu.ExceptedDataLength() + _responseApduTrailerLength];

            var receivePci = new SCardPCI();
            var sendPci = SCardPCI.GetPci(this._reader.ActiveProtocol());

            var sc = this._reader.Transmit(
                        sendPci,
                        this._commandApdu.Bytes(),
                        receivePci,
                        ref receiveBuffer);

            if (sc != SCardError.Success)
            {
                throw new Exception("Error: " + SCardHelper.StringifyError(sc));
            }

            return receiveBuffer;
        }


        public SCardProtocol Protocol()
        {
            return this._commandApdu.Protocol();
        }

        public int ExceptedDataLength()
        {
            return this._commandApdu.ExceptedDataLength();
        }

        public IsoCase Case()
        {
            return this._commandApdu.Case();
        }
    }
}
