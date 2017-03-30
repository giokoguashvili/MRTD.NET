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
        public Tag(IBinary berTvl)
        {
            _berTvl = berTvl;
        }
        public byte[] Bytes()
        {
            return new ConcatenatedBinaries(
                        new Binary(_berTvl.Bytes().Take(1)),      
                        new SubsequentBytes(_berTvl)
                    ).Bytes();
        }
    }
}
