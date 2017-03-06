using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HelloWord.Cryptography
{
    public class KSeed : IBinary
    {
        private readonly IBinary _hash;
        public KSeed(IBinary hash)
        {
            this._hash = hash;
        }
        public byte[] AsBinary()
        {
            return this._hash
                .AsBinary()
                .Take(16)
                .ToArray();
        }
    }
}
