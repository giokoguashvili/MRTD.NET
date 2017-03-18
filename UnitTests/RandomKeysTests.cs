using System;
using NUnit.Framework;
using HelloWord.Cryptography;
using HelloWord.Cryptography.RandomKeys;

namespace UnitTests
{
    [TestFixture]
    public class RandomKeysTests
    {
        [Test]
        public void GenerateRandomBytes()
        {
            Assert.AreNotEqual(
                    new Hex(
                            new RandomBytes(8)
                        ).ToString(),
                    new Hex(
                            new RandomBytes(8)
                        ).ToString()
                );

            var rnd = new RandomBytes(8);
            Assert.AreEqual(
                    new Hex(
                            rnd
                        ).ToString(),
                    new Hex(
                            rnd
                        ).ToString()
                );
        }
    }
}
