using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HelloWord.Infrastructure
{
    public class Len
    {
        private readonly IBinary _data;

        public Len(IBinary data)
        {
            _data = data;
        }

        public int Result()
        {
            return _data.Bytes().Length;
        }

        public bool Is(int len)
        {
            return Result() == len;
        }

        public bool IsEmpty()
        {
            return Is(0);
        }
    }
}
