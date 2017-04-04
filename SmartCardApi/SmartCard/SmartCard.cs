using SmartCardApi.DataGroups;
using SmartCardApi.SmartCard.Reader;

namespace SmartCardApi.SmartCard
{
    public class SmartCard
    {
        private readonly IBacReader _bacReader;

        public SmartCard(IBacReader bacReader)
        {
            _bacReader = bacReader;
        }

        public DG1 DG1()
        {
            return new DG1(_bacReader);
        }
    }
}
