using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Linq;
using System.Reactive.Threading.Tasks;
using System.Text;
using System.Threading.Tasks;
using DemoApp.Infrastructure;
using SmartCardApi.DataGroups.Content;

namespace DemoApp
{
    public class DataObjects : IDataObjectContent
    {
        private readonly ISource<ISmartCard> _smartCardInsertEvents;
        private readonly int _onlyFirstEventCount = 1;
        public DataObjects(ISource<ISmartCard> smartCardInsertEvents)
        {
            _smartCardInsertEvents = smartCardInsertEvents;
        }

        private DataObjectsContent AsDataObjectsContent(ISmartCard smartCard)
        {
            Console.WriteLine("start");
            var dg1Content = smartCard.DG1().Content();
            var dg2Content = smartCard.DG2().Content();
            var dg7Content = smartCard.DG7().Content();
            var dg11Content = smartCard.DG11().Content();
            var dg12Content = smartCard.DG12().Content();
            Console.WriteLine("done");
            return new DataObjectsContent(
                dg1Content,
                dg2Content,
                dg7Content,
                dg11Content,
                dg12Content
            );
        }
        public async Task<DataObjectsContent> Content()
        {
            return await _smartCardInsertEvents
                            .Source()
                            .Take(_onlyFirstEventCount)
                            .Select(AsDataObjectsContent)
                            .ToTask();
        }
        
    }
}
