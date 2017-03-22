using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HelloWord.Infrastructure;

namespace HelloWord.Cryptography
{
    public class D : IBinary
    {
        private readonly IBinary _kSeed;
        private readonly IBinary _c;
        public D(IBinary kSeed, IBinary c)
        {
            this._kSeed = kSeed;
            this._c = c;
        }

        public byte[] Bytes()
        {
            return new ConcatenatedBinaries(
                    _kSeed,
                    _c
                ).Bytes();
                
        }
    }
}
