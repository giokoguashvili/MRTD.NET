using System;
using System.Collections.Generic;
using System.Linq;

namespace HelloWord.Infrastructure
{
    public class Binary : IBinary, INumber
    {
        private readonly byte[] _bytes;

        public Binary(byte _byte) : this(new byte[] { _byte }) { }

        public Binary() : this(new byte[0]) {}

        public Binary(IEnumerable<byte> bytes) : this(bytes.ToArray())
        {}

        public Binary(byte[] bytes)
        {
            this._bytes = bytes;
        }
        public byte[] Bytes()
        {
            return this._bytes;
        }

        public bool Is(int len)
        {
            return Value() == len;
        }

        public bool IsEmpty()
        {
            return Is(0);
        }

        public int Value()
        {
            return _bytes.Length;
        }
    }
}
