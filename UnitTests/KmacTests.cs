using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using HelloWord.Cryptography;
using UnitTests.FakeObjects;

namespace UnitTests
{
    [TestClass]
    public class KmacTests
    {
        [TestMethod]
        public void Calculate_the_basic_access_key_Kmac()
        {
            Assert.AreEqual(
                    "7962D9ECE03D1ACD4C76089DCE131543",
                    new Hex(
                        new Kmac(
                            new FkKSeed()
                        )
                    ).AsString()
                );
        }
    }
}
