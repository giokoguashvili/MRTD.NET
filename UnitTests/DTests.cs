using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using HelloWord.Cryptography;
using UnitTests.FakeObjects;

namespace UnitTests
{
    [TestClass]
    public class DTests
    {
        [TestMethod]
        public void Concatenate_Kseed_and_c_for_kEnc()
        {
            Assert.AreEqual(
                    "239AB9CB282DAF66231DC5A4DF6BFBAE00000002",
                    new Hex(
                        new D(
                            new FkKSeed(),
                            "00000002"
                        )
                    ).AsString()
                );
        }

        [TestMethod]
        public void Concatenate_Kseed_and_c_for_kMac()
        {
            Assert.AreEqual(
                    "239AB9CB282DAF66231DC5A4DF6BFBAE00000001",
                    new Hex(
                        new D(
                            new FkKSeed(),
                            "00000001"
                        )
                    ).AsString()
                );
        }
    }
}
