using HelloWord.Cryptography;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTests.FakeObjects
{
    public class FkRNDifd : IBinary
    {
        public byte[] Binary()
        {
            return new BinaryHex("781723860C06C226").Binary();
        }
    }
}
