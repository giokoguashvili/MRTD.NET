using HelloWord.Cryptography;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HelloWord.Infrastructure;

namespace UnitTests.FakeObjects
{
    public class FkRNDic : IBinary
    {
        public byte[] Bytes()
        {
            return new BinaryHex("4608F91988702212").Bytes();
        }
    }
}
