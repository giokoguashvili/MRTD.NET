using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HelloWord.Cryptography
{
    public class D : IBinary
    {
        private readonly IBinary _kSeed;
        private readonly byte[] _c;
        public D(IBinary kSeed, string c) : this(kSeed, new BinaryHex(c).Binary()) { }
        public D(IBinary kSeed, byte[] c)
        {
            this._kSeed = kSeed;
            this._c = c;
        }

        public byte[] Binary()
        {
            return this._kSeed
                .Binary()
                .Concat(this._c)
                .ToArray();
        }
    }
}
