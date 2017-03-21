using System;
using NUnit.Framework;
using HelloWord.Cryptography;
using HelloWord.Infrastructure;
using UnitTests.FakeObjects;

namespace UnitTests
{
    [TestFixture]
    public class KmacTests
    {
        [Test]
        public void Calculate_the_basic_access_key_Kmac()
        {
            Assert.AreEqual(
                    "7962D9ECE03D1ACD4C76089DCE131543",
                    new Hex(
                        new Kmac(
                            new FkKSeed()
                        )
                    ).ToString()
                );
        }
    }
}
