using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using HelloWord.Cryptography;

namespace UnitTests
{
    [TestClass]
    public class AdjustedParityTests
    {
        [TestMethod]
        [DataRow("AB94FDECF2674FDF", "AB94FCEDF2664EDF")]
        [DataRow("B9B391F85D7F76F2", "B9B291F85D7F77F2")]
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
