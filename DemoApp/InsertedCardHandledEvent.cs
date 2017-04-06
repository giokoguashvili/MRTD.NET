using System;
using SmartCardApi.SmartCard;

namespace DemoApp
{
    public class InsertedCardHandledEvent : IObserver<SmartCard>
    {
        public void OnNext(SmartCard smartCard)
        {
            Console.WriteLine("start");
            var dg1Content = smartCard.DG1().Content();
            var dg2Content = smartCard.DG2().Content();
            var dg7Content = smartCard.DG7().Content();
            var dg11Content = smartCard.DG11().Content();
            var dg12Content = smartCard.DG12().Content();
            Console.WriteLine("done");
        }

        public void OnError(Exception error)
        {
            throw new NotImplementedException();
        }

        public void OnCompleted()
        {
            throw new NotImplementedException();
        }
    }
}
