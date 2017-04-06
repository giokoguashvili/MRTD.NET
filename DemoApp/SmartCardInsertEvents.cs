using System;
using System.Diagnostics.SymbolStore;
using System.Reactive.Disposables;
using System.Reactive.Linq;
using PCSC;
using SmartCardApi.Infrastructure;
using SmartCardApi.MRZ;
using SmartCardApi.SmartCard;
using SmartCardApi.SmartCard.Reader;

namespace DemoApp
{
    public class SmartCardInsertEvents : IObservable<SmartCard>
    {
        private readonly ISymbols _mrzInfo;
        private readonly IObservable<ISCardReader> _smartCardReaderConnectEvents;

        public SmartCardInsertEvents(
                ISymbols mrzInfo,
                IObservable<ISCardReader> smartCardReaderConnectEvents
            )
        {
            _mrzInfo = mrzInfo;
            _smartCardReaderConnectEvents = smartCardReaderConnectEvents;
        }
        public IDisposable Subscribe(IObserver<SmartCard> observer)
        {
            _smartCardReaderConnectEvents  
                .Select(reader =>
                {
                    Console.WriteLine(reader.ReaderName);
                    var smartCard = new SmartCard(
                        new BacReader(
                            new SecuredReader(
                                _mrzInfo,
                                new WrReader(
                                    new LogedReader(
                                        reader
                                    )
                                )
                            )
                        )
                    );
                    observer.OnNext(smartCard);
                    return true;
                }).Subscribe();
           
            return Disposable.Empty;
        }
    }
}
