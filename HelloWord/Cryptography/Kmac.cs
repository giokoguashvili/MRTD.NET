using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HelloWord.Cryptography
{
    public class Kmac
    {
        private readonly D _d;
        public Kmac(D d)
        {
            this._d = d;
        }

        public Kmac(KSeed kSeed) : this(new D(kSeed, "00000002")) { }

    }
}
