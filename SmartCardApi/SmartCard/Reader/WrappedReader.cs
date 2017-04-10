using System;
using PCSC;
using SmartCardApi.Infrastructure;

namespace SmartCardApi.SmartCard.Reader
{
    public class WrappedReader : IReader
    {

        private readonly ISCardReader _reader;
        private readonly int _responseApduTrailerLength = 2; // 0x02
        public WrappedReader(ISCardReader reader)
        {
            _reader = reader;
        }

        public void Dispose()
        {
           _reader.Dispose();
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
