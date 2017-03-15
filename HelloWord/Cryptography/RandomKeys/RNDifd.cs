using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HelloWord.Cryptography.RandomKeys
{
    public class RNDifd : IBinary
    {
        private readonly int _randomBytesCount = 8;
        public byte[] Bytes()
        {
            return new RandomBytes(this._randomBytesCount).Bytes();
        }
    }
}
