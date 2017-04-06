using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Linq;
using System.Reactive.Threading.Tasks;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using SmartCardApi.DataGroups.Content;
using SmartCardApi.Infrastructure;

namespace DemoApp
{
    public class SmartCardContent
    {
        private readonly ISymbols _mrzInfo;

        public SmartCardContent(ISymbols mrzInfo)
        {
            _mrzInfo = mrzInfo;
        }
        public async Task<DG1Content> Content()
        {
     
            return await new SmartCardInsertEventsSource(
                _mrzInfo,
                new SmartCardReaderConnectEventsSource()
            )
            .Select(smartCard =>
            {
                Console.WriteLine("start");
                var dg1Content = smartCard.DG1().Content();
                var dg2Content = smartCard.DG2().Content();
                var dg7Content = smartCard.DG7().Content();
                var dg11Content = smartCard.DG11().Content();
                var dg12Content = smartCard.DG12().Content();
                Console.WriteLine("done");
                return dg1Content;
            })
            .FirstAsync()
            .ToTask();
        }
    }
}
