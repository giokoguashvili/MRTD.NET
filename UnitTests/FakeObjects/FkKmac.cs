using HelloWord.Cryptography;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HelloWord.Infrastructure;

namespace UnitTests.FakeObjects
{
    public class FkKmac : IBinary
    {
        public byte[] Bytes()
        {
            return new BinaryHex("7962D9ECE03D1ACD4C76089DCE131543").Bytes();
        }
    }
}
