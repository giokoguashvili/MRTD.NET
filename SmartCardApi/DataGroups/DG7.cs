using SmartCardApi.DataGroups.Content;
using SmartCardApi.Infrastructure;
using SmartCardApi.SmartCard.Reader;

namespace SmartCardApi.DataGroups
{
    public class DG7 : IDataGroup<DG7Content>
    {
        private readonly IBacReader _bacReader;
        private readonly IBinary _fid = new BinaryHex("0107");
        public DG7(IBacReader bacReader)
        {
            _bacReader = bacReader;
        }
        public byte[] Bytes()
        {
            return _bacReader.DGData(_fid).Bytes();
        }

        public DG7Content Content()
        {
            return new DG7Content(_bacReader.DGData(_fid)); //_bacReader.DGData(_fid)
        }
    }
}
