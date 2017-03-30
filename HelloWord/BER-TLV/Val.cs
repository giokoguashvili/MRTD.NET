using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HelloWord.Infrastructure;

namespace HelloWord.BER_TLV
{
    public class Val : IBinary
    {
        private readonly IBinary _berTvl;
        public Val(IBinary berTvl)
        {
            _berTvl = berTvl;
        }
        public byte[] Bytes()
        {
            var valueLength = new Hex(
                                new Len(_berTvl)
                              ).ToInt();
            return _berTvl
                .Bytes()
                .Reverse()
                .Take(valueLength)
                .Reverse()
                .ToArray();
        }
    }
}
