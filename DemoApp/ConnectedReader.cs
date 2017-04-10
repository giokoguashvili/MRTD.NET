using System;
using System.Diagnostics;
using System.Threading;
using DemoApp.Infrastructure;
using PCSC;
using SmartCardApi.SmartCard.Reader;

namespace DemoApp
{
    public class ConnectedReader : Optional<IReader>, IDisposable
    {
        private readonly string _readerName;
        private readonly ISCardReader _reader;

        public ConnectedReader(string readerName, ISCardContext cardContext)
        {
            Debug.WriteLine("Create Reader TreadID " + Thread.CurrentThread.ManagedThreadId);
            _readerName = readerName;
            _reader = new SCardReader(cardContext);
        }

        public void Dispose()
        {
            _reader.Dispose();
        }

        public override IOption<IReader> GetEnumerator()
        {
            Debug.WriteLine("GetEnumerator Reader TreadID " + Thread.CurrentThread.ManagedThreadId);
            var cardError = _reader.Connect(_readerName, SCardShareMode.Shared, SCardProtocol.Any);
            SCardProtocol proto;
            SCardState state;
            byte[] atr;
            var readerNames = new[] { _readerName };
            var sc = _reader.Status(
                out readerNames,
                out state,
                out proto,
                out atr
            );

            if (sc != SCardError.Success)
            {
                Console.WriteLine("Could not begin transaction. {0}", SCardHelper.StringifyError(cardError));
                return new Option<IReader>();
            }

            sc = _reader.BeginTransaction();
            if (cardError != SCardError.Success)
            {
                Console.WriteLine("Could not begin transaction. {0}", SCardHelper.StringifyError(cardError));
                return new Option<IReader>();
            }

            Console.WriteLine("Connected with protocol {0} in state {1}", proto, state);
            Console.WriteLine("Card ATR: {0}", BitConverter.ToString(atr));

            return new Option<IReader>(
                        new WrappedReader(
                            //new LogedReader(
                                _reader
                            //)
                        )
                    );
        }
    }
}
