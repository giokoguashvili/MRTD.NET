using System;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using PCSC;
using PCSC.Iso7816;
using SmartCardApi.Infrastructure;

namespace SmartCardApi.SmartCardReader
{
    public class LogedReader : ISCardReader
    {
        private readonly ISCardReader _reader;

        public LogedReader(ISCardReader reader)
        {
            _reader = reader;
        }
        public SCardError Transmit(IntPtr sendPci, byte[] sendBuffer, SCardPCI receivePci, ref byte[] receiveBuffer)
        {
            Debug.WriteLine("TreadID " + Thread.CurrentThread.ManagedThreadId);
            var sce = _reader.Transmit(
                        sendPci,
                        sendBuffer,
                        receivePci,
                        ref receiveBuffer
                   );

            var claName = String.Empty;
            var mode = "Unprotected";
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
                if (sendBuffer.First() == 0x0C)
                {
                    mode = "Protected";
                }
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
                          "\n{5}_{3}:\n CAPDU: {0}\n RAPDU: {2}\nSW1SW2: {4}\n    Le: {1}\n",
                          new Hex(
                              new Binary(sendBuffer)
                          ),
                          receiveBuffer.Length,
                          new Hex(
                              new Binary(receiveBuffer)
                          ),
                          claName,
                          new Hex(new Binary(receiveBuffer.Reverse().Take(2).Reverse())),
                          mode
                      );
            }
            catch (Exception e)
            {
                Console.WriteLine("Wrong Length for Hex");
            }
           
            return sce;
        }

        SCardProtocol ISCardReader.ActiveProtocol
        {
            get { return _reader.ActiveProtocol; }
        }

        public IBinary Transmit(IBinary rawCommandApdu)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            _reader.Dispose();
        }

        public SCardError Connect(string readerName, SCardShareMode mode, SCardProtocol preferredProtocol)
        {
            throw new NotImplementedException();
        }

        public SCardError Disconnect(SCardReaderDisposition disconnectExecution)
        {
            throw new NotImplementedException();
        }

        public SCardError Reconnect(SCardShareMode mode, SCardProtocol preferredProtocol, SCardReaderDisposition initialExecution)
        {
            throw new NotImplementedException();
        }

        public SCardError BeginTransaction()
        {
            throw new NotImplementedException();
        }

        public SCardError EndTransaction(SCardReaderDisposition disposition)
        {
            throw new NotImplementedException();
        }

        public SCardError Transmit(IntPtr sendPci, byte[] sendBuffer, int sendBufferLength, SCardPCI receivePci, byte[] receiveBuffer,
            ref int receiveBufferLength)
        {
            throw new NotImplementedException();
        }

        public SCardError Transmit(IntPtr sendPci, byte[] sendBuffer, ref byte[] receiveBuffer)
        {
            throw new NotImplementedException();
        }

        public SCardError Transmit(SCardPCI sendPci, byte[] sendBuffer, SCardPCI receivePci, ref byte[] receiveBuffer)
        {
            throw new NotImplementedException();
        }

        public SCardError Transmit(byte[] sendBuffer, int sendBufferLength, byte[] receiveBuffer, ref int receiveBufferLength)
        {
            throw new NotImplementedException();
        }

        public SCardError Transmit(byte[] sendBuffer, byte[] receiveBuffer, ref int receiveBufferLength)
        {
            throw new NotImplementedException();
        }

        public SCardError Transmit(byte[] sendBuffer, ref byte[] receiveBuffer)
        {
            throw new NotImplementedException();
        }

        public SCardError Control(IntPtr controlCode, byte[] sendBuffer, ref byte[] receiveBuffer)
        {
            throw new NotImplementedException();
        }

        public SCardError Status(out string[] readerName, out SCardState state, out SCardProtocol protocol, out byte[] atr)
        {
            throw new NotImplementedException();
        }

        public SCardError GetAttrib(IntPtr attributeId, byte[] attribute, out int attributeBufferLength)
        {
            throw new NotImplementedException();
        }

        public SCardError GetAttrib(IntPtr attributeId, out byte[] attribute)
        {
            throw new NotImplementedException();
        }

        public SCardError GetAttrib(SCardAttribute attributeId, byte[] attribute, out int attributeBufferLength)
        {
            throw new NotImplementedException();
        }

        public SCardError GetAttrib(SCardAttribute attributeId, out byte[] attribute)
        {
            throw new NotImplementedException();
        }

        public SCardError SetAttrib(IntPtr attributeId, byte[] attribute, int attributeBufferLength)
        {
            throw new NotImplementedException();
        }

        public SCardError SetAttrib(IntPtr attributeId, byte[] attribute)
        {
            throw new NotImplementedException();
        }

        public SCardError SetAttrib(SCardAttribute attributeId, byte[] attribute, int attributeBufferLength)
        {
            throw new NotImplementedException();
        }

        public SCardError SetAttrib(SCardAttribute attributeId, byte[] attribute)
        {
            throw new NotImplementedException();
        }

        public string ReaderName { get; private set; }
        public ISCardContext CurrentContext { get; private set; }
        public SCardShareMode CurrentShareMode { get; private set; }

        public IntPtr CardHandle { get; private set; }
        public bool IsConnected { get; private set; }
    }
}
