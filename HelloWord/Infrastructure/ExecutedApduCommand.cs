using System;
using HelloWord.ISO7816.CommandAPDU;
using HelloWord.SmartCard;
using PCSC;
using PCSC.Iso7816;

namespace HelloWord.Infrastructure
{
    public class ExecutedCommandApdu : IBinary
    {
        private readonly IBinary _rawCommandApdu;
        private readonly IReader _reader;
        private readonly int _responseApduTrailerLength = 2; // 0x02
        public ExecutedCommandApdu(
                IBinary rawCommandApdu,
                IReader reader
            )
        {
            this._rawCommandApdu = rawCommandApdu;
            this._reader = reader;
        }

        public byte[] Bytes()
        {
            var receiveBuffer = new byte[50 + _responseApduTrailerLength];
            var receivePci = new SCardPCI();
            var sendPci = SCardPCI.GetPci(this._reader.ActiveProtocol());

            var sc = this._reader.Transmit(
                            sendPci,
                            this._rawCommandApdu.Bytes(),
                            receivePci,
                            ref receiveBuffer
                        );

            if (sc != SCardError.Success)
            {
                throw new Exception("Error: " + SCardHelper.StringifyError(sc));
            }
            return receiveBuffer;
        }
    }
}
