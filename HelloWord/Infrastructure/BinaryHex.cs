using System;
using System.Linq;

namespace HelloWord.Infrastructure
{
    public class BinaryHex : IBinary
    {
        private readonly string _str;
        public BinaryHex(string str)
        {
            this._str = str;
        }

        public byte[] Bytes()
        {
            var formatedString = _str;
            if (formatedString.Length % 2 == 1)
            {
                formatedString = String.Format("0{0}", _str);
            }

            return Enumerable.Range(0, formatedString.Length)
                    .Where(x => x % 2 == 0)
                    .Select(x => Convert.ToByte(formatedString.Substring(x, 2), 16))
                    .ToArray();
        }
    }
}
