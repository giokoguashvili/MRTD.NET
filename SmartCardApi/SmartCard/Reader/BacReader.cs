using SmartCardApi.DataGroups.DG;
using SmartCardApi.Infrastructure;
using SmartCardApi.USB;

namespace SmartCardApi.SmartCard.Reader
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
 
            //new ConnectedReaders()
            return new DGData(
                    fid,
                    _securedReader
                );
        }

        public void Dispose()
        {
            _securedReader.Dispose();
        }
    }
}
