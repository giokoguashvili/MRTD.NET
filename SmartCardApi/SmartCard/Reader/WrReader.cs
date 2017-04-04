using System;
using PCSC;
using SmartCardApi.Infrastructure;

namespace SmartCardApi.SmartCard.Reader
{
    public class WrReader : IReader
    {
        private readonly ISCardReader _reader;
        private readonly int _responseApduTrailerLength = 2; // 0x02
        public WrReader(ISCardReader reader)
        {
            _reader = reader;
        }

        public IBinary Transmit(IBinary rawCommandApdu)
        {
            var receiveBuffer = new byte[1024 + _responseApduTrailerLength];
            var receivePci = new SCardPCI();
            var sendPci = SCardPCI.GetPci(SCardProtocol.T1);

            var sc = _reader.Transmit(
                            sendPci,
                            rawCommandApdu.Bytes(),
                            receivePci,
                            ref receiveBuffer
                        );

            if (sc != SCardError.Success)
            {
                throw new Exception("Error: " + SCardHelper.StringifyError(sc));
            }
            return new Binary(receiveBuffer);
        }
    }
}
