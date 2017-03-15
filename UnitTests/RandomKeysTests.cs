using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using HelloWord.Cryptography;
using HelloWord.Cryptography.RandomKeys;

namespace UnitTests
{
    [TestClass]
    public class RandomKeysTests
    {
        [TestMethod]
        public void GenerateRandomBytes()
        {
            Assert.AreNotEqual(
                    new Hex(
                            new RandomBytes(8)
                        ).AsString(),
                    new Hex(
                            new RandomBytes(8)
                        ).AsString()
                );

            var rnd = new RandomBytes(8);
            Assert.AreEqual(
                    new Hex(
                            rnd
                        ).AsString(),
                    new Hex(
                            rnd
                        ).AsString()
                );
        }
    }
}
