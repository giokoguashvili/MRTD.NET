using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HelloWord.Infrastructure;
using PCSC;

namespace HelloWord.SmartCard
{
    public class LogedReader : IReader
    {
        private readonly ISCardReader _reader;

        public LogedReader(ISCardReader reader)
        {
            _reader = reader;
        }
        public SCardProtocol ActiveProtocol()
        {
            return _reader.ActiveProtocol;
        }

        public SCardError Transmit(IntPtr sendPci, byte[] sendBuffer, SCardPCI receivePci, ref byte[] receiveBuffer)
        {
            var sce = _reader.Transmit(
                        sendPci,
                        sendBuffer,
                        receivePci,
                        ref receiveBuffer
                   );
            Console.WriteLine(
                "\nCAPDU: {0}\nRAPDU: {2}\nLe: {1}",
                new Hex(
                    new Binary(sendBuffer)
                ),
                receiveBuffer.Length,
                new Hex(
                    new Binary(receiveBuffer)
                )
            );
            return sce;
        }
    }
}
