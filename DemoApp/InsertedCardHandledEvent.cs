using System;
using System.Reactive.Linq;
using SmartCardApi.SmartCard;

namespace DemoApp
{
    public class HandledSmartCardInsertEvent 
    {
        private readonly IObservable<SmartCard> _smartCardInsertEvents;

        public HandledSmartCardInsertEvent(IObservable<SmartCard> smartCardInsertEvents)
        {
            _smartCardInsertEvents = smartCardInsertEvents;
        }
        public void Handle()
        {
            _smartCardInsertEvents
                .Select(smartCard =>
                {
                    Console.WriteLine("start");
                    var dg1Content = smartCard.DG1().Content();
                    var dg2Content = smartCard.DG2().Content();
                    var dg7Content = smartCard.DG7().Content();
                    var dg11Content = smartCard.DG11().Content();
                    var dg12Content = smartCard.DG12().Content();
                    Console.WriteLine("done");
                    return false;
                })
                .Subscribe();
        }
    }
}
