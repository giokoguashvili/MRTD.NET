using HelloWord.Cryptography;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HelloWord.Infrastructure;

namespace UnitTests.FakeObjects
{
    public class FkKenc : IBinary
    {
        public byte[] Bytes()
        {
            return new BinaryHex("AB94FDECF2674FDFB9B391F85D7F76F2").Bytes();
        }
    }
}
