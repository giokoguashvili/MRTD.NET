using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HelloWord.Infrastructure;

namespace HelloWord.Cryptography
{
    public class KSmac : IBinary
    {
        private readonly IBinary _kSeedIc;

        public KSmac(IBinary kSeedIc)
        {
            _kSeedIc = kSeedIc;
        }

        public byte[] Bytes()
        {
            return new Kmac(_kSeedIc).Bytes();
        }
    }
}
