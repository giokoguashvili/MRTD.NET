using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace HelloWord.Cryptography
{
    public class SHA1 : IBinary
    {
        private readonly byte[] _bytes;

        public SHA1(IBinary binary) : this(binary.Binary()) { }
        public SHA1(string str) : this(Encoding.UTF8.GetBytes(str)) { }
        public SHA1(byte[] bytes)
        {
            _bytes = bytes;
        }

        public byte[] Binary()
        {
            using (SHA1Managed sha1 = new SHA1Managed())
            {
                return sha1.ComputeHash(this._bytes);
            }
        }
    }
}
