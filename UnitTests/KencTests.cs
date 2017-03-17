using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using HelloWord.Cryptography;
using UnitTests.FakeObjects;

namespace UnitTests
{
    [TestClass]
    public class KencTests
    {
        [TestMethod]
        public void Calculate_the_basic_access_key_Kenc()
        {
            Assert.AreEqual(
                    "AB94FDECF2674FDFB9B391F85D7F76F2",
                    new Hex(
                        new Kenc(
                            new FkKSeed()
                        )
                    ).ToString()
                );
        }
    }
}
