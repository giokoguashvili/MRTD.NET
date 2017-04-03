using HelloWord.Cryptography.RandomKeys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HelloWord.Infrastructure;

namespace HelloWord.Cryptography
{
    public class Eifd : IBinary
    {
        private readonly IBinary _kEnc;
        private readonly IBinary _s;
        public Eifd(IBinary s, IBinary kEnc)
        {
            _s = s;
            _kEnc = kEnc;
        }

        public byte[] Bytes()
        {
            return new TripleDES(
                        _kEnc,
                        _s
                   )
                   .Encrypted()
                   .Bytes();
        }
    }
}
