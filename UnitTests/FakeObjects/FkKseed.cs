using HelloWord.Cryptography;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTests.FakeObjects
{
    public class FkKSeed : IBinary
    {
        public byte[] Binary()
        {
            return new BinaryHex("239AB9CB282DAF66231DC5A4DF6BFBAE").Binary();
        }
    }
}
