using System;
using PCSC;
using SmartCardApi.Infrastructure;

namespace SmartCardApi.SmartCard.Reader
{
    public class ConnectedReader : IDisposable
    {
        private readonly string _readerName;
        private readonly ISCardReader _reader;

        public ConnectedReader(string readerName, ISCardContext cardContext)
        {
            _readerName = readerName;
            _reader = new SCardReader(cardContext);
        }
        public IReader Connected()
        {
            var cardError = _reader.Connect(_readerName, SCardShareMode.Shared, SCardProtocol.Any);
            SCardProtocol proto;
            SCardState state;
            byte[] atr;
            var readerNames = new[] {_readerName};
            var sc = _reader.Status(
                            out readerNames,
                            out state,
                            out proto,
                            out atr
                        );

            if (sc != SCardError.Success)
            {
                Console.WriteLine("Could not begin transaction.");
                Console.ReadKey();
            }

            sc = _reader.BeginTransaction();
            if (cardError != SCardError.Success)
            {
                throw new Exception(String.Format("Error message: {0}\n", SCardHelper.StringifyError(cardError)));
            }

            Console.WriteLine("Connected with protocol {0} in state {1}", proto, state);
            Console.WriteLine("Card ATR: {0}", BitConverter.ToString(atr));

            return new WrappedReader(
                    new LogedReader(_reader)
                );
        }

        public void Dispose()
        {
            //_reader.Dispose();
        }
    }
}
