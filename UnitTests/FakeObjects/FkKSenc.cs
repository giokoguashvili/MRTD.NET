using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HelloWord.Cryptography;
using HelloWord.Infrastructure;

namespace UnitTests.FakeObjects
{
    public class FkKSenc : IBinary
    {
        public byte[] Bytes()
        {
            return new BinaryHex("979EC13B1CBFE9DCD01AB0FED307EAE5").Bytes();
        }
    }
}
