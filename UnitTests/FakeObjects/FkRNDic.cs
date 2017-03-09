using HelloWord.Cryptography;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTests.FakeObjects
{
    public class FkRNDic : IBinary
    {
        public byte[] Binary()
        {
            return new BinaryHex("4608F91988702212").Binary();
        }
    }
}
