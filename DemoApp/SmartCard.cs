using System;
using DemoApp.Infrastructure;
using PCSC;
using SmartCardApi.DataGroups;
using SmartCardApi.Infrastructure;
using SmartCardApi.SmartCard.Reader;

namespace SmartCardApi.SmartCard
{
    public class SmartCard : ISmartCard, IDisposable
    {
        private readonly IBacReader _bacReader;

        public SmartCard(ISymbols mrzInfo, IReader connectedReader)
        {
            _bacReader = new BacReader(
                            new SecuredReader(
                                mrzInfo,
                                connectedReader
                            )
                        );
        }

        public SmartCard(IBacReader bacReader)
        {
            _bacReader = bacReader;
        }
        public DG1 DG1()
        {
            return new DG1(_bacReader);
        }
        public DG2 DG2()
        {
            return new DG2(_bacReader);
        }
        public DG7 DG7()
        {
            return new DG7(_bacReader);
        }
        public DG11 DG11()
        {
            return new DG11(_bacReader);
        }
        public DG12 DG12()
        {
            return new DG12(_bacReader);
        }

        public void Dispose()
        {
            _bacReader.Dispose();
        }
    }
}
