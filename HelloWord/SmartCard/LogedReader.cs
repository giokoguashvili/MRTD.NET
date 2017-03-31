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

            var claName = String.Empty;
            try
            {
                var claNamesDictionary = ((InstructionCode[]) Enum.GetValues(typeof(InstructionCode)))
                    .Zip(
                        Enum.GetNames(typeof(InstructionCode)),
                        (first, second) => new {Value = (int) first, Name = second}
                    )
                    .ToDictionary((item) => item.Value, item => item.Name);

                var claValue = new Hex(new Binary(sendBuffer.Skip(1).Take(1).ToArray())).ToInt();
                claName = claNamesDictionary[claValue];
            }
            catch (Exception ex)
            {
                Console.Write(
                        "\n{0} : {1}\n",
                        ex.Message,
                        new Hex(new Binary(sendBuffer.Skip(1).Take(1).ToArray()))
                    );
            }

            try
            {
                Console.WriteLine(
                          "\n{3}:\n CAPDU: {0}\n RAPDU: {2}\nSW1SW2: {4}\n    Le: {1}\n",
                          new Hex(
                              new Binary(sendBuffer)
                          ),
                          receiveBuffer.Length,
                          new Hex(
                              new Binary(receiveBuffer)
                          ),
                          claName,
                          new Hex(new Binary(receiveBuffer.Reverse().Take(2).Reverse()))
                      );
            }
            catch (Exception e)
            {
                Console.WriteLine("Wrong Length for Hex");
            }
           
            return sce;
        }
    }
}
