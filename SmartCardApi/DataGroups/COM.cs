using SmartCardApi.DataGroups.Content;
using SmartCardApi.Infrastructure;
using SmartCardApi.Infrastructure.Interfaces;
using SmartCardApi.SmartCardReader;

namespace SmartCardApi.DataGroups
{
    public class COM : IDataGroup<COMContent>
    {
        private readonly IBinary _cachedDgData;
        private readonly IBinary _fid = new BinaryHex("011E");
        public COM(IBacReader bacReader)
        {
            _cachedDgData = new Cached(bacReader.DGData(_fid));
        }
        public byte[] Bytes()
        {
            return _cachedDgData.Bytes();
        }

        public COMContent Content()
        {
            return new COMContent(_cachedDgData);
        }
    }
}
