using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Linq;
using System.Text;
using System.Threading.Tasks;
using DemoApp.Infrastructure;
using PCSC;
using SmartCardApi.SmartCard.Reader;

namespace DemoApp
{
    public class SmartCardConnectedEvent : ISource<IReader>
    {
        private readonly ISCardContext _cardContext;

        public SmartCardConnectedEvent(ISCardContext cardContext)
        {
            _cardContext = cardContext;
        }
        public IObservable<IReader> Source()
        {
            return Observable
                .Create<IReader>(observer =>
                {
                    var reader = new ConnectedReaders(_cardContext).FirstOrDefault();
                    if (reader != null)
                        observer.OnNext(reader);
                    return reader;
                });
        }
    }
}
