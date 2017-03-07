using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HelloWord.Cryptography
{
    public class AdjustedParity : IBinary
    {
        private readonly IBinary _binary;
        public AdjustedParity(IBinary binary)
        {
            this._binary = binary;
        }

        public byte[] AsBinary()
        {
            return this._binary
               .AsBinary()
               .Select(b => new Parity(b).Adjusted().Result())
               .ToArray();
        }
    }
}
