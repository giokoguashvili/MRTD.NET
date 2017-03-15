using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using HelloWord.Cryptography;
using UnitTests.FakeObjects;

namespace UnitTests
{
    [TestClass]
    public class MAC3Tests
    {
        [TestMethod]
        public void Compute_MAC_Algorithm_3()
        {
            Assert.AreEqual(
                    "5F1448EEA8AD90A7",
                    new Hex(
                        new MAC3(
                            new FkEifd(),
                            new FkKmac()
                        )
                    ).AsString()
                );
        }
    }
}
