using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HelloWord.Infrastructure;
using Org.BouncyCastle.Asn1;

namespace HelloWord.BER_TLV
{
    public class TLV
    {
        private readonly IBinary _binaryHex;
        public TLV(IBinary binaryHex)
        {
            _binaryHex = binaryHex;
        }

        public IBinary Tag()
        {
            return new Tag(_binaryHex);
        }

        public IBinary Len()
        {
            return new Len(_binaryHex);
        }

        public IBinary Val()
        {
            return new Binary();
            //return new Val(_binaryHex);
        }

        public IEnumerable<TLV> Data()
        {
            return new TLV(_binaryHex).Data();
        }
    }
}
