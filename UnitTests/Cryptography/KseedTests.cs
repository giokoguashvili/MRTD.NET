using HelloWord.Cryptography;
using HelloWord.Infrastructure;
using NUnit.Framework;

namespace UnitTests.Cryptography
{
    [TestFixture]
    public class KseedTests
    {
        [Test]
        public void Take_the_most_significant_16_bytes_to_form_the_Kseed()
        {
            Assert.AreEqual(
                    "239AB9CB282DAF66231DC5A4DF6BFBAE",
                    new Hex(
                        new Kseed(
                            new BinaryHex("239AB9CB282DAF66231DC5A4DF6BFBAEDF477565")
                        )
                    ).ToString()
                );
        }
    }
}
