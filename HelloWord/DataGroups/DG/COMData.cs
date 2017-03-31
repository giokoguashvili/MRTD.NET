using System.Collections.Generic;
using System.Linq;
using System.Text;
using HelloWord.Infrastructure;

namespace HelloWord.DataGroups.DG
{
    public class COMData
    {
        private readonly IBinary _comData;

        public COMData(IBinary comData)
        {
            _comData = comData;
        }

        public override string ToString()
        {

           // ICollection<Tlv> tlvs = Tlv.ParseTlv(new Hex(_comData).ToString());
            return Encoding.ASCII
                .GetString(
                    _comData
                    .Bytes()
                    .Skip(5)
                    .ToArray()
                );
        }
    }
}
