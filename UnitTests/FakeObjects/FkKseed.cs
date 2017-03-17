using HelloWord.Cryptography;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HelloWord.Infrastructure;

namespace UnitTests.FakeObjects
{
    public class FkKSeed : IBinary
    {
        public byte[] Bytes()
        {
            return new BinaryHex("239AB9CB282DAF66231DC5A4DF6BFBAE").Bytes();
        }
    }
}
