using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HelloWord.Infrastructure;
using HelloWord.ISO7816.CommandAPDU.Body;
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

        private IBinary FirstExistingTVL()
        {
            return new ConcatenatedBinaries(
                        Tag(),
                        Len(),
                        Val()
                   );
        }

        private IEnumerable<IBinary> ExtractData(byte[] constructedBerTlv)
        {
            var firstExistingTVL = FirstExistingTVL();
            return new List<IBinary>()
            {
                firstExistingTVL
            }.Concat(ExtractData(new byte[] {1}));
        }
    }
}
