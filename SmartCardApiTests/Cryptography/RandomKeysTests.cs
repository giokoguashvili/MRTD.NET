using NUnit.Framework;
using SmartCardApi.Cryptography.RandomKeys;
using SmartCardApi.Infrastructure;

namespace SmartCardApiTests.Cryptography
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
