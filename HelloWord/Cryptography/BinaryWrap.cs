using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HelloWord.Cryptography
{
    public class Binary : IBinary
    {
        private readonly byte[] _bytes;
        public Binary(byte[] bytes)
        {
            this._bytes = bytes;
        }
        public byte[] Bytes()
        {
            return this._bytes;
        }
    }
}
