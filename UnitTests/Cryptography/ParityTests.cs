using HelloWord.Cryptography;
using NUnit.Framework;

namespace UnitTests.Cryptography
{
    [TestFixture]
    public class ParityTests
    {
        [Test]
        [TestCase(253, 252)]
        [TestCase(103, 102)]
        [TestCase(79, 78)]
        public void Adjust_Parity_Bits_on_Bytes(int exp, int input)
        {
            Assert.AreEqual(
                    exp,
                    new Parity((byte)input).Adjusted().Result()
                );
        }
    }
}
