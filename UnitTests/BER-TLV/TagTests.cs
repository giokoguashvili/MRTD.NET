using HelloWord.Infrastructure;
using HelloWord.TVL;
using NUnit.Framework;

namespace UnitTests
{
    [TestFixture]
    public class TagTests
    {
        [Test]
        public void Extract_BER_Tag()
        {
            Assert.AreEqual(
                    "5F0E",
                    new Hex(
                        new Tag(
                            new BinaryHex("5F0E2727")
                        )
                    ).ToString()
                );
        }
    }
}
