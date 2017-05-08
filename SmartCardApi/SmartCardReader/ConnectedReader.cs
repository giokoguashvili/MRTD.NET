using System;
using System.Diagnostics;
using System.Threading;
using PCSC;
using SmartCardApi.Infrastructure;
using SmartCardApi.Infrastructure.Option;

namespace SmartCardApi.SmartCardReader
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

        public override IOption<IReader> Content()
        {
            Debug.WriteLine("GetEnumerator Reader TreadID " + Thread.CurrentThread.ManagedThreadId);
            var cardError = _reader.Connect(_readerName, SCardShareMode.Shared, SCardProtocol.Any);
            if (cardError != SCardError.Success)
            {
                Console.WriteLine("Could not begin transaction. {0}", SCardHelper.StringifyError(cardError));
                return new Option<IReader>();
            }
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
                Console.WriteLine("Could not begin transaction. {0}", SCardHelper.StringifyError(sc));
                return new Option<IReader>();
            }

            sc = _reader.BeginTransaction();
            if (sc != SCardError.Success)
            {
                Console.WriteLine("Could not begin transaction. {0}", SCardHelper.StringifyError(sc));
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
