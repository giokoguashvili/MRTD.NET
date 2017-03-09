using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HelloWord.Cryptography
{
    public class Hex
    {
        private readonly byte[] _bytes;

        public Hex(IBinary binary) : this(binary.Binary()) { }
        public Hex(byte[] bytes)
        {
            this._bytes = bytes;
        }
        public string AsString()
        {
            return this._bytes
                        .ToList()
                        .Aggregate(
                            String.Empty,
                            (prev, next) => prev + next.ToString("X2")
                        );
        }
    }
}
