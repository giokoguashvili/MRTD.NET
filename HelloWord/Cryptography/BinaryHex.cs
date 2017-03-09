using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HelloWord.Cryptography
{
    public class BinaryHex : IBinary
    {
        private readonly string _str;
        public BinaryHex(string str)
        {
            this._str = str;
        }

        public byte[] Binary()
        {
            return Enumerable.Range(0, this._str.Length)
                    .Where(x => x % 2 == 0)
                    .Select(x => Convert.ToByte(this._str.Substring(x, 2), 16))
                    .ToArray();
        }
    }
}
