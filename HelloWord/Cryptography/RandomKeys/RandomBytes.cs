using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HelloWord.Cryptography.RandomKeys
{
    public class RandomBytes : IBinary
    {
        private static readonly Random rndGenerator = new Random();
        private readonly int _bytesCount;
        public RandomBytes(int bytesCount)
        {
            this._bytesCount = bytesCount;
        }

        public byte[] Bytes()
        {
            var result = new byte[_bytesCount];
            rndGenerator.NextBytes(result);
            return result;
        }
    }
}
