using SmartCardApi.DataGroups.Content;
using SmartCardApi.Infrastructure;
using SmartCardApi.SmartCard.Reader;

namespace SmartCardApi.DataGroups
{
    public class DG1 : IDataGroup<DG1Content>
    {
        private readonly IBacReader _bacReader;
        private readonly IBinary _fid = new BinaryHex("0101");
        public DG1(IBacReader bacReader)
        {
            _bacReader = bacReader;
        }
        public byte[] Bytes()
        {
            return _bacReader.DGData(_fid).Bytes();
        }

        public DG1Content Content()
        {
            return new DG1Content(_bacReader.DGData(_fid));
        }
    }
}
