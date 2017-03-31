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

            //ICollection<Tlv> tlvs = Tlv.ParseTlv(new Hex(_dg1Data).ToString());
            var berTlv = new BerTLV(_dg1Data);
            return Encoding.ASCII
                .GetString(
                    new BinaryHex(
                        berTlv
                            .Data
                            .First()
                            .Val
                    ).Bytes()
                );
        }
    }
}
