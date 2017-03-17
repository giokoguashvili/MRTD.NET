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
            this._s = s;
            this._kEnc = kEnc;
        }

        public byte[] Bytes()
        {
            return new TripleDES(
                        this._kEnc,
                        this._s
                   )
                   .Encrypted()
                   .Bytes();
        }
    }
}
