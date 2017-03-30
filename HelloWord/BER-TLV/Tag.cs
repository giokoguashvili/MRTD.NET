using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HelloWord.Infrastructure;

namespace HelloWord.BER_TLV
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
            return new ConcatenatedBinaries(
                        new Binary(berTlvFirstByte()),      
                        new SubsequentBytes(_berTvl)
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
