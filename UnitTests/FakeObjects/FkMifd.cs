using HelloWord.Cryptography;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HelloWord.Infrastructure;

namespace UnitTests.FakeObjects
{
    public class FkMifd : IBinary
    {
        public byte[] Bytes()
        {
            return new BinaryHex("5F1448EEA8AD90A7").Bytes();
        }
    }
}
