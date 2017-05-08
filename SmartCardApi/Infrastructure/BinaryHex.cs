using System;
using System.Linq;
using SmartCardApi.Infrastructure.Interfaces;

namespace SmartCardApi.Infrastructure
{
    public class BinaryHex : IBinary
    {
        private readonly string _str;
        public BinaryHex(string str)
        {
            _str = str;
        }

        public byte[] Bytes()
        {
            return Enumerable.Range(0, _str.Length)
                    .Where(x => x % 2 == 0)
                    .Select(x => Convert.ToByte(_str.Substring(x, 2), 16))
                    .ToArray();
        }
    }
}
