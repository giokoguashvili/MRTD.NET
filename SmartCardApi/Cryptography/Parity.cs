using System;
using System.Linq;

namespace SmartCardApi.Cryptography
{
    public class Parity : IParity
    {
        private readonly byte _b;
        public Parity(byte b)
        {
            _b = b;
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
            return isOddParity(_b) ? (IParity)new AdjustedOddParity(_b) : new AdjustedEvenParity(_b);
        }

        public byte Result()
        {
            return Adjusted().Result();
        }
    }
}
