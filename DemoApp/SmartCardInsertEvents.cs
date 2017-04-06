using System;
using PCSC;
using SmartCardApi.MRZ;
using SmartCardApi.SmartCard;
using SmartCardApi.SmartCard.Reader;

namespace DemoApp
{
    public class SmartCardInsertedEvents : IObservable<SmartCard>
    {
        private readonly ISCardReader _reader;

        public SmartCardInsertedEvents(ISCardReader reader)
        {
            _reader = reader;
        }
        public IDisposable Subscribe(IObserver<SmartCard> observer)
        {
            var mrzInfo = new MRZInfo(
                "12IB34415",
                new DateTime(1992, 06, 16),
                new DateTime(2022, 10, 08)
            ); //"12IB34415792061602210089" K

            //var mrzInfo = new MRZInfo("15IC69034", new DateTime(1996,11,26), new DateTime(2026, 06, 11)); //"496112612606118" Bagdavadze
            //var mrzInfo = "13ID37063295110732402055";     // + Shako
            //var mrzInfo = "13IB90080296040761709252";   // + guka 
            //var mrzInfo = "13ID40308689022472402103";     // + Giorgio

            var smartCard = new SmartCard(
                new BacReader(
                    new SecuredReader(
                        mrzInfo,
                        new WrReader(
                            new LogedReader(
                                _reader
                            )
                        )
                    )
                )
            );
            observer.OnNext(smartCard);
            return _reader;
        }
    }
}
