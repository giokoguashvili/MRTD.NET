using HelloWord.DataGroups.DG;
using HelloWord.Infrastructure;

namespace HelloWord.SmartCard.Reader
{
    public class BacReader : IBacReader
    {
        private readonly IReader _securedReader;
        public BacReader(IReader securedReader)
        {
            _securedReader = securedReader;
        }

        public IBinary DGData(IBinary fid)
        {
            return new DGData(
                    fid,
                    _securedReader
                );
        }
    }
}
