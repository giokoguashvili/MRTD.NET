using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using HelloWord.Cryptography;

namespace UnitTests
{
    [TestClass]
    public class ParityTests
    {
        [TestMethod]
        [DataRow(253, 252)]
        [DataRow(103, 102)]
        [DataRow(79, 78)]
        public void Adjust_Parity_Bits_on_Bytes(int exp, int input)
        {
            Assert.AreEqual(
                    exp,
                    new Parity((byte)input).Adjusted().Result()
                );
        }
    }
}
