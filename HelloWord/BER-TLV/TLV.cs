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
        private readonly IBinary _berTvl;
        public TLV(IBinary berTvl)
        {
            _berTvl = berTvl;
        }

        public IBinary Tag()
        {
            return new Tag(_berTvl);
        }

        public IBinary Len()
        {
            return new Len(_berTvl);
        }

        public IBinary Val()
        {
            return new Val(_berTvl);
        }

        public IEnumerable<TLV> Data()
        {
            return new TLV(_berTvl).Data();
        }
    }
}
