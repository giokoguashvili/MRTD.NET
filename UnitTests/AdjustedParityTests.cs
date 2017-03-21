using System;
using NUnit.Framework;
using HelloWord.Cryptography;
using HelloWord.Infrastructure;

namespace UnitTests
{
    [TestFixture]
    public class AdjustedParityTests
    {
        [Test]
        [TestCase("AB94FDECF2674FDF", "AB94FCEDF2664EDF")]
        [TestCase("B9B391F85D7F76F2", "B9B291F85D7F77F2")]
        public void Adjust_Parity_Bits_on_Keys(string exc, string input)
        {
            Assert.AreEqual(
                    exc,
                    new Hex(
                        new AdjustedParity(
                            new BinaryHex(input)
                        )
                    ).ToString()
                );
        }
    }
}
