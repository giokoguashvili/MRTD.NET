using HelloWord.Cryptography;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HelloWord.Infrastructure;

namespace UnitTests.FakeObjects
{
    public class FkRNDifd : IBinary
    {
        public byte[] Bytes()
        {
            return new BinaryHex("781723860C06C226").Bytes();
        }
    }
}
