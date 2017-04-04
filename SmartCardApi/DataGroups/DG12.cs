using SmartCardApi.DataGroups.Content;
using SmartCardApi.Infrastructure;
using SmartCardApi.SmartCard.Reader;

namespace SmartCardApi.DataGroups
{
    public class DG12 : IDataGroup<DG12Content>
    {
        private readonly IBinary _fid = new BinaryHex("010C");
        private readonly IBinary _dgData;
        public DG12(IBacReader bacReader)
        {
            _dgData = bacReader.DGData(_fid);
        }
        public byte[] Bytes()
        {
            return _dgData.Bytes();
        }

        public DG12Content Content()
        {
            return new DG12Content(_dgData); //_bacReader.DGData(_fid)
        }
    }
}
