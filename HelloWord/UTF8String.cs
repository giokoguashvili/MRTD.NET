using HelloWord.Cryptography;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HelloWord
{
    public class UTF8String : IBinary
    {
        private readonly string _str;
        public UTF8String(string str)
        {
            this._str = str;
        }

        public byte[] Binary()
        {
            return Encoding.UTF8.GetBytes(this._str);
        }
    }
}
