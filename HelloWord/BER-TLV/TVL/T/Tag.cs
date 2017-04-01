using System.Linq;
using HelloWord.Infrastructure;

namespace HelloWord.TVL
{
  
    public class Tag : IBinary
    {
        private readonly IBinary _berTvl;
        private readonly byte _b5_b1_one = 0x1F; // 0b0001 0b1111
        private readonly byte _b6_one = 0x40; // 0b0010 0b0000
        public Tag(IBinary berTvl)
        {
            _berTvl = berTvl;
        }
        public byte[] Bytes()
        {
            return new CombinedBinaries(
                        new Binary(_berTvl.Bytes().First()),      
                        new TagSubsequentBytes(_berTvl)
                    ).Bytes();
        }

        private byte berTlvFirstByte()
        {
            return _berTvl.Bytes().FirstOrDefault();
        }

        public bool HasConstructedData()
        {
            return (berTlvFirstByte() & _b6_one) == _b6_one;
        }
    }
}
