using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using HelloWord.Infrastructure;

namespace HelloWord.Cryptography
{
    public class SHA1 : IBinary
    {
        private readonly IBinary _binary;

        public SHA1(IBinary binary)
        {
            this._binary = binary;
        }

        public byte[] Bytes()
        {
            return new SHA1Managed()
                .ComputeHash(this._binary.Bytes());
        }
    }
}
