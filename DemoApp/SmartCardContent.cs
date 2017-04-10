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
        public async Task<DataObjectsContent> Content()
        {
            return
                await new SmartCardInsertEvents(
                        _mrzInfo,
                        new SmartCardReaderConnectEvents()
                    )
                    .Source()
                    .Take(1)
                    .Select(sc => new DataObjects(sc).Content())
                    .ToTask();
        }
    }
}
