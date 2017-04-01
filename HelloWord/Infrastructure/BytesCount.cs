using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HelloWord.Infrastructure
{
    public class BytesCount : INumber
    {
        private readonly IBinary _data;
        public BytesCount(string hexStr) : this(new BinaryHex(hexStr))
        {}
        public BytesCount(IBinary data)
        {
            _data = data;
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
            return _data.Bytes().Length;
        }
    }
}
