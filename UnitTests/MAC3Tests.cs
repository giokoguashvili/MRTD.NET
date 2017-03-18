using System;
using NUnit.Framework;
using HelloWord.Cryptography;
using UnitTests.FakeObjects;

namespace UnitTests
{
    [TestFixture]
    public class MAC3Tests
    {
        [Test]
        public void Compute_MAC_Algorithm_3()
        {
            Assert.AreEqual(
                    "5F1448EEA8AD90A7",
                    new Hex(
                        new MAC3(
                            new FkEifd(),
                            new FkKmac()
                        )
                    ).ToString()
                );
        }
    }
}
