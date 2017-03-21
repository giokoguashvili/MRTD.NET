using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HelloWord.Infrastructure;

namespace HelloWord.Cryptography
{
    public class Kic : IBinary
    {
        private readonly IBinary _r;

        public Kic(IBinary r)
        {
            _r = r;
        }
        public byte[] Bytes()
        {
            return _r
                .Bytes()
                .Skip(16)
                .ToArray();
        }
    }
}
