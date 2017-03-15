using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HelloWord.Cryptography
{
    public class Kenc : IBinary
    {
        private readonly string _c = "00000001";
        private readonly IBinary _kSeed;

        public Kenc(IBinary kSeed)
        {
            this._kSeed = kSeed;
        }

        public byte[] Bytes()
        {
            return new DESKeys(
                        new SHA1(
                            new D(this._kSeed, this._c)
                        )
                    )
                    .Key()
                    .Bytes();
        }
    }
}
