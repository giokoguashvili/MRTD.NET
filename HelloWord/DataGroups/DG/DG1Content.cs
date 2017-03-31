using System.Collections.Generic;
using System.Linq;
using System.Text;
using HelloWord.Infrastructure;

namespace HelloWord.DataGroups.DG
{
    public class DG1Content 
    {
        private readonly IBinary _dg1Data;

        public DG1Content(IBinary dg1Data)
        {
            _dg1Data = dg1Data;
        }

        public override string ToString()
        {
            var str = new Hex(_dg1Data).ToString();
           // ICollection<Tlv> tlvs = Tlv.ParseTlv(str);
            var berTlv = new BerTLV(_dg1Data);
            var res = Encoding.UTF8
                .GetString(
                    new BinaryHex(
                        //((HelloWord.BerTLV)berTlv.Data[3]).Val
                        berTlv
                            .Data
                            .First()
                            .Val
                    ).Bytes()
                );

            return res;
        }
    }
}
