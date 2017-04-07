using System;
using System.Reactive.Linq;
using System.Reactive.Threading.Tasks;
using System.Threading.Tasks;
using SmartCardApi.DataGroups.Content;
using SmartCardApi.Infrastructure;
using SmartCardApi.SmartCard;


namespace DemoApp
{
    public class SmartCardContent
    {
        private readonly ISymbols _mrzInfo;

        public SmartCardContent(ISymbols mrzInfo)
        {
            _mrzInfo = mrzInfo;
        }

        private DG1Content DgContent(SmartCard smartCard)
        {
            Console.WriteLine("start");
            var dg1Content = smartCard.DG1().Content();
            var dg2Content = smartCard.DG2().Content();
            var dg7Content = smartCard.DG7().Content();
            var dg11Content = smartCard.DG11().Content();
            var dg12Content = smartCard.DG12().Content();
            Console.WriteLine("done");
            //smartCard.Dispose();
            return dg1Content;
        }

        public async Task<DG1Content> Content()
        {
            return
                await new SmartCardInsertEvents(
                        _mrzInfo,
                        new SmartCardReaderConnectEvents()
                    )
                    .Source()
                    .Take(1)
                    .Select(DgContent)
                    .ToTask();
        }
    }
}
