using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HelloWord.Cryptography
{
    public class DESKeys : IKeys
    {
        private readonly IBinary _binary;
        public DESKeys(IBinary binary)
        {
            this._binary = binary;
        }

        public IBinary Ka()
        {
            return new AdjustedParity(
                    this._binary
                        .Binary()
                        .Take(8)
                        .ToArray()
                );
        }

        public IBinary Kb()
        {
            return new AdjustedParity(
                    this._binary
                        .Binary()
                        .Skip(8)
                        .Take(8)
                        .ToArray()
                );
        }

        public IBinary Key()
        {
            return new AdjustedParity(
                    this._binary
                        .Binary()
                        .Take(16)
                        .ToArray()  
                );
        }
    }
}
