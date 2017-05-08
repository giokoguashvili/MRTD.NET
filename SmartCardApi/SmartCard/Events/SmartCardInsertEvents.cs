using System;
using System.Reactive.Linq;
using SmartCardApi.Infrastructure;
using SmartCardApi.Infrastructure.Interfaces;
using SmartCardApi.SmartCardReader;

namespace SmartCardApi.SmartCard.Events
{
    public class SmartCardInsertEvents : ISource<ISmartCard>
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

        public IObservable<ISmartCard> Source()
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
