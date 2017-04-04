using SmartCardApi.DataGroups.Content;
using SmartCardApi.Infrastructure;
using SmartCardApi.SmartCard.Reader;

namespace SmartCardApi.DataGroups
{
    public class DG2 : IDataGroup<DG2Content>
    {
        private readonly IBacReader _bacReader;
        private readonly IBinary _fid = new BinaryHex("0102");
        public DG2(IBacReader bacReader)
        {
            _bacReader = bacReader;
        }
        public byte[] Bytes()
        {
            return _bacReader.DGData(_fid).Bytes();
        }

        public DG2Content Content()
        {
            return new DG2Content(_bacReader.DGData(_fid)); //_bacReader.DGData(_fid)
        }
    }
}
