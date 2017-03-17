using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HelloWord.Infrastructure;

namespace HelloWord.Cryptography
{
    public class Kmac : IBinary
    {
        private readonly string _c = "00000002";
        private readonly IBinary _kSeed;

        public Kmac(IBinary kSeed)
        {
            this._kSeed = kSeed;
        }

        public byte[] Bytes()
        {
            return new AdjustedParity(
                        new SHA1(
                            new D(this._kSeed, this._c)
                        )
                        .Bytes()
                        .Skip(0)
                        .Take(16)
                        .ToArray()
                    )
                    .Bytes();
        }
    }
}
