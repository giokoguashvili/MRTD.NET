using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HelloWord.Infrastructure;

namespace HelloWord.Cryptography
{
    public class Kseed : IBinary
    {
        private readonly IBinary _hash;
        public Kseed(IBinary hash)
        {
            _hash = hash;
        }
        public byte[] Bytes()
        {
            return _hash
                .Bytes()
                .Take(16)
                .ToArray();
        }
    }
}
