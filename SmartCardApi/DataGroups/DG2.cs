using SmartCardApi.DataGroups.Content;
using SmartCardApi.Infrastructure;
using SmartCardApi.Infrastructure.Interfaces;
using SmartCardApi.SmartCardReader;

namespace SmartCardApi.DataGroups
{
    public class DG2 : IDataGroup<DG2Content>
    {
        private readonly IBinary _fid = new BinaryHex("0102");
        private readonly IBinary _dgData;
        public DG2(IBacReader bacReader)
        {
            _dgData = bacReader.DGData(_fid);
        }
        public byte[] Bytes()
        {
            return _dgData.Bytes();
        }

        public DG2Content Content()
        {
            return new DG2Content(_dgData); //_bacReader.DGData(_fid)
        }
    }
}
