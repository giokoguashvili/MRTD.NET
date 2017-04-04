using SmartCardApi.DataGroups.Content;
using SmartCardApi.Infrastructure;
using SmartCardApi.SmartCard.Reader;

namespace SmartCardApi.DataGroups
{
    public class DG7 : IDataGroup<DG7Content>
    {
        private readonly IBinary _fid = new BinaryHex("0107");
        private readonly IBinary _dgData;
        public DG7(IBacReader bacReader)
        {
            _dgData = bacReader.DGData(_fid);
        }
        public byte[] Bytes()
        {
            return _dgData.Bytes();
        }

        public DG7Content Content()
        {
            return new DG7Content(_dgData); //_bacReader.DGData(_fid)
        }
    }
}
