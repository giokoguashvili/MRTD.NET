using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HelloWord.Infrastructure;

namespace HelloWord.Cryptography.RandomKeys
{
    public class RNDifd : IBinary
    {
        private readonly int _randomBytesCount = 8;
        public byte[] Bytes()
        {
            return new RandomBytes(_randomBytesCount).Bytes();
        }
    }
}
