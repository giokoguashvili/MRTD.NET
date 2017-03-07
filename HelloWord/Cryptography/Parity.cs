using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HelloWord.Cryptography
{
    public class Parity : IParity
    {
        private readonly byte _b;
        public Parity(byte b)
        {
            this._b = b;
        }

        public IParity Adjusted()
        {

            Func<byte, bool> isOddParity = (b) =>
            {
                var hightBit = (1 << 7);
                return Enumerable
                    .Range(0, 7)
                    .Select(index => (hightBit >> index) == ((hightBit >> index) & b))
                    .Where(item => item == true)
                    .Count() % 2 == 0;
            };

            return isOddParity(this._b) ? (IParity)new AdjustedOddParity(this._b) : new AdjustedEvenParity(this._b);
        }

        public byte Result()
        {
            return this.Adjusted().Result();
        }
    }
}
