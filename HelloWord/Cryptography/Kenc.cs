using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HelloWord.Cryptography
{
    public class Kenc
    {
        private readonly D _d;
        public Kenc(D d)
        {
            this._d = d;
        }

        public Kenc(KSeed kSeed) : this(new D(kSeed, "00000001")) { }
    }
}
