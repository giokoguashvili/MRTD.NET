using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HelloWord.Cryptography
{
    public class AdjustedParity : IBinary
    {
        private readonly byte[] _bites;

        public AdjustedParity(byte[] bites)
        {
            this._bites = bites;
        }
        public AdjustedParity(IBinary binary) : this(binary.AsBinary()) { }
        public byte[] AsBinary()
        {
            return this._bites
               .Select(b => new Parity(b).Adjusted().Result())
               .ToArray();
        }
    }
}
