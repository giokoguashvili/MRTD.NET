using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HelloWord.Cryptography
{
    public class Hex
    {
        private readonly IBinary _binary;

        public Hex(IBinary binary)
        { 
            this._binary = binary;
        }
        public string AsString()
        {
            return this._binary
                .Bytes()
                .ToList()
                .Aggregate(
                    String.Empty,
                    (prev, next) => prev + next.ToString("X2")
                );
        }
    }
}
