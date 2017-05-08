using System;
using System.Reactive.Linq;
using System.Reactive.Threading.Tasks;
using System.Threading.Tasks;
using SmartCardApi.Infrastructure;
using SmartCardApi.Infrastructure.Interfaces;
using SmartCardApi.SmartCardReader;

namespace SmartCardApi.DataGroups
{
    public class DataGroups
    {
        private readonly ISource<ISmartCard> _smartCardInsertEvents;
        private readonly int _onlyFirstEventCount = 1;
        public DataGroups(ISource<ISmartCard> smartCardInsertEvents)
        {
            _smartCardInsertEvents = smartCardInsertEvents;
        }

        private DataGroupsContent AsDataGroupsContent(ISmartCard smartCard)
        {
            Console.WriteLine("start");
            var dg1Content = smartCard.DG1().Content();
            var dg2Content = smartCard.DG2().Content();
            var dg7Content = smartCard.DG7().Content();
            var dg11Content = smartCard.DG11().Content();
            var dg12Content = smartCard.DG12().Content();
            //var cardSecurity = smartCard.CardSecurity().Content();
            Console.WriteLine("done");
            //return null;
            return new DataGroupsContent(
                dg1Content,
                dg2Content,
                dg7Content,
                dg11Content,
                dg12Content
            );
        }
        public async Task<DataGroupsContent> Content()
        {
            return await _smartCardInsertEvents
                            .Source()
                            .Take(_onlyFirstEventCount)
                            .Select(AsDataGroupsContent)
                            .ToTask();
        }
        
    }
}
