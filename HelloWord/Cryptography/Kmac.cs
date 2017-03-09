using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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

        public byte[] Binary()
        {
            return new AdjustedParity(
                        new SHA1(
                            new D(this._kSeed, this._c)
                        )
                        .Binary()
                        .Skip(0)
                        .Take(16)
                        .ToArray()
                    )
                    .Binary();
        }
    }
}
