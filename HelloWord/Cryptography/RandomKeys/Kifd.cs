using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HelloWord.Cryptography.RandomKeys
{
    public class Kifd : IBinary
    {
        private readonly int _randomBytesCount = 16;
        public byte[] Bytes()
        {
            return new RandomBytes(this._randomBytesCount)
                 .Bytes();
        }
    }
}
