using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HelloWord.Cryptography.RandomKeys
{
    public class RNDic : IBinary
    {
        public byte[] Binary()
        {
            return new BinaryHex("4608F91988702212").Binary();
        }
    }
}
