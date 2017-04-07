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
    public class SmartCardInsertEvents : ISource<SmartCard>
    {
        private readonly ISymbols _mrzInfo;
        private readonly ISource<IReader> _smartCardReaderConnectEvents;

        public SmartCardInsertEvents(
                ISymbols mrzInfo,
                ISource<IReader> smartCardReaderConnectEvents
            )
        {
            _mrzInfo = mrzInfo;
            _smartCardReaderConnectEvents = smartCardReaderConnectEvents;
        }

        public IObservable<SmartCard> Source()
        {
            return _smartCardReaderConnectEvents
                        .Source()
                        .Select(connectedReader => new SmartCard(
                                                        _mrzInfo,
                                                        connectedReader
                                                    )
                        );
        }
    }
}
