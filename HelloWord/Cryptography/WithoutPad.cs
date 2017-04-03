using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HelloWord.Infrastructure;

namespace HelloWord.Cryptography
{
    public class WithoutPad : IBinary
    {
        private readonly IBinary _data;

        public WithoutPad(IBinary data)
        {
            _data = data;
        }
        public byte[] Bytes()
        {
            return _data
                .Bytes()
                .Reverse()
                .SkipWhile(b => b == 0x00)
                .Skip(1)
                .Reverse()
                .ToArray();
        }
    }
}
