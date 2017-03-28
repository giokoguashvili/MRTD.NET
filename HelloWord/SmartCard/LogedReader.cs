using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ExceptionServices;
using System.Text;
using HelloWord.Infrastructure;
using PCSC;
using PCSC.Iso7816;

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

            try
            {
                var claNamesDictionary = ((InstructionCode[]) Enum.GetValues(typeof(InstructionCode)))
                    .Zip(
                        Enum.GetNames(typeof(InstructionCode)),
                        (first, second) => new {Value = (int) first, Name = second}
                    )
                    .ToDictionary((item) => item.Value, item => item.Name);

                var claValue = new Hex(new Binary(sendBuffer.Take(2).ToArray())).ToInt();
                var claName = claNamesDictionary[claValue];


                Console.WriteLine(
                    "{3}:\nCAPDU: {0}\nRAPDU: {2}\nLe: {1}",
                    new Hex(
                        new Binary(sendBuffer)
                    ),
                    receiveBuffer.Length,
                    new Hex(
                        new Binary(receiveBuffer)
                    ),
                    claName
                );
            }
            catch (Exception ex)
            {
                Console.Write(
                        "\n{0}\n",
                        ex.Message
                    );
            }
            
            return sce;
        }
    }
}
