using HelloWord.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloWord.BER_TLV.TVL
{
    public class ShortLen : IBinary
    {
        private readonly IBinary _berTlvWithoutTag;
        public ShortLen(IBinary berTvlWithoutTag)
        {
            _berTlvWithoutTag = berTvlWithoutTag;
        }
        public byte[] Bytes()
        {
            return _berTlvWithoutTag
                        .Bytes()
                        .Take(1)
                        .ToArray();
        }
    }
}
