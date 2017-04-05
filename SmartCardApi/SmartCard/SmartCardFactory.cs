using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PCSC;
using SmartCardApi.Infrastructure;
using SmartCardApi.SmartCard.Reader;

namespace SmartCardApi.SmartCard
{
    public class SmartCardFactory
    {
        private readonly ISymbols _mrzInfo;

        public SmartCardFactory(
                ISymbols mrzInfo
            )
        {
            _mrzInfo = mrzInfo;
        }
        public SmartCard SmartCard()
        {
            throw new NotImplementedException();
            //var reader = new ReaderFactory().ConnectedReader()
            //return new SmartCard(
            //            new BacReader(
            //                new SecuredReader(
            //                        _mrzInfo,
            //                        new WrReader(
            //                            new LogedReader(
            //                                reader
            //                            )
            //                        )
            //                    )
            //            )
            //        );
        }
    }
}
