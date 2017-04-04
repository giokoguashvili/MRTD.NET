using SmartCardApi.DataGroups.Content;
using SmartCardApi.Infrastructure;
using SmartCardApi.SmartCard.Reader;

namespace SmartCardApi.DataGroups
{
    public class DG11 : IDataGroup<DG11Content>
    {

        private readonly IBinary _fid = new BinaryHex("010B");
        private readonly IBinary _dgData;
        public DG11(IBacReader bacReader)
        {
            _dgData = bacReader.DGData(_fid);
        }
        public byte[] Bytes()
        {
            return _dgData.Bytes();
        }

        public DG11Content Content()
        {
            return new DG11Content(_dgData); //_bacReader.DGData(_fid)
        }
    }
}
