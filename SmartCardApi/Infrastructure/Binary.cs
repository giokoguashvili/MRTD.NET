using System.Collections.Generic;
using System.Linq;
using SmartCardApi.Infrastructure.Interfaces;

namespace SmartCardApi.Infrastructure
{
    public class Binary : IBinary, INumber
    {
        private readonly byte[] _bytes;

        public Binary(byte _byte) : this(new [] { _byte }) { }

        public Binary() : this(new byte[0]) {}

        public Binary(IEnumerable<byte> bytes) : this(bytes.ToArray())
        {}

        public Binary(byte[] bytes)
        {
            _bytes = bytes;
        }
        public byte[] Bytes()
        {
            return _bytes;
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
