using System.Threading.Tasks;
using SmartCardApi.DataGroups;
using SmartCardApi.Infrastructure;
using SmartCardApi.Infrastructure.Interfaces;
using SmartCardApi.SmartCard.Events;

namespace SmartCardApi.SmartCard
{
    public class SmartCardContent
    {
        private readonly ISymbols _mrzInfo;

        public SmartCardContent(ISymbols mrzInfo)
        {
            _mrzInfo = mrzInfo;
        }
        public async Task<DataGroupsContent> Content()
        {
            return await new DataGroups.DataGroups(
                            new SmartCardInsertEvents(
                                _mrzInfo,
                                new SmartCardReaderConnectEvents()
                            )
                        ).Content();
        }
    }
}
