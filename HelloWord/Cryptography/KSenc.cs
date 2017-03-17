using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HelloWord.Infrastructure;

namespace HelloWord.Cryptography
{
    public class KSenc : IBinary
    {
        private readonly IBinary _kSeedIc;

        public KSenc(IBinary kSeedIc)
        {
            _kSeedIc = kSeedIc;
        }

        public byte[] Bytes()
        {
            return new Kenc(_kSeedIc).Bytes();
        }
    }
}
