using System;
using NUnit.Framework;
using HelloWord.Cryptography;
using HelloWord.Infrastructure;
using UnitTests.FakeObjects;

namespace UnitTests
{
    [TestFixture]
    public class DTests
    {
        [Test]
        public void Concatenate_Kseed_and_c_for_kEnc()
        {
            Assert.AreEqual(
                    "239AB9CB282DAF66231DC5A4DF6BFBAE00000002",
                    new Hex(
                        new D(
                            new FkKSeed(),
                            new BinaryHex("00000002")
                        )
                    ).ToString()
                );
        }

        [Test]
        public void Concatenate_Kseed_and_c_for_kMac()
        {
            Assert.AreEqual(
                    "239AB9CB282DAF66231DC5A4DF6BFBAE00000001",
                    new Hex(
                        new D(
                            new FkKSeed(),
                             new BinaryHex("00000001")
                        )
                    ).ToString()
                );
        }
    }
}
