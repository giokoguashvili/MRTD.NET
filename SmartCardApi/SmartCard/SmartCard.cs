using PCSC;
using SmartCardApi.DataGroups;
using SmartCardApi.SmartCard.Reader;

namespace SmartCardApi.SmartCard
{
    public class SmartCard
    {
        private readonly IBacReader _bacReader;

        public SmartCard(IBacReader bacReader)
        {
            var contextFactory = ContextFactory.Instance;
            SCardMonitor monitor = new SCardMonitor(contextFactory, SCardScope.System);

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
    }
}
