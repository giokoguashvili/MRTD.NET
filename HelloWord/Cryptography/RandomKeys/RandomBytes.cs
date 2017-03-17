using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HelloWord.Infrastructure;

namespace HelloWord.Cryptography.RandomKeys
{
    public class RandomBytes : IBinary
    {
        private static readonly Random rndGenerator = new Random();
        private readonly byte[] _rndBytes;
        public RandomBytes(int bytesCount)
        {
            this._rndBytes = new byte[bytesCount];
            rndGenerator.NextBytes(_rndBytes);
        }


        public byte[] Bytes()
        {
            return this._rndBytes;
        }
    }
}
