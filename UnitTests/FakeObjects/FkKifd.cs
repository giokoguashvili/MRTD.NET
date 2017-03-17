using HelloWord.Cryptography;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HelloWord.Infrastructure;

namespace UnitTests.FakeObjects
{
    public class FkKifd : IBinary
    {
        public byte[] Bytes()
        {
            return new BinaryHex("0B795240CB7049B01C19B33E32804F0B").Bytes();
        }
    }
}
