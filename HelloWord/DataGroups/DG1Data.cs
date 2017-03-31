using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BerTlv;
using HelloWord.Infrastructure;

namespace HelloWord.DataGroups
{
    public class DG1Data 
    {
        private readonly IBinary _dg1Data;

        public DG1Data(IBinary dg1Data)
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
