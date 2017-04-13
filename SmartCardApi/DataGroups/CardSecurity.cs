using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SmartCardApi.DataGroups.Content;
using SmartCardApi.Infrastructure;
using SmartCardApi.SmartCardReader;
using SmartCardApi.View;

namespace SmartCardApi.DataGroups
{
    public class CardSecurity : IDataGroup<DG1Content>
    {
        private readonly IBinary _fid = new BinaryHex("0101");
        private readonly IBinary _dgData;
        public CardSecurity(IBacReader bacReader)
        {
            _dgData = bacReader.DGData(_fid);
        }
        public byte[] Bytes()
        {
            return _dgData.Bytes();
        }
        public DG1Content Content()
        {
            var stra = Encoding.ASCII.GetString(_dgData.Bytes());
            var hex = new Hex(_dgData).ToString();
            var berTLV = new BerTLV(hex);
            var str = new ASCIIString(hex).ToString();
            return new DG1Content(_dgData);
        }
    }
}
