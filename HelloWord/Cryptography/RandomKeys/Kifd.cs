using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HelloWord.Cryptography.RandomKeys
{
    public class Kifd : IBinary
    {
        private readonly int _bytesCount = 16;

        public byte[] Binary()
        {
            return new RandomBytes(this._bytesCount).Binary();
        }
    }
}
