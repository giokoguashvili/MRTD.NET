using HelloWord.Infrastructure;
using HelloWord.TVL;
using NUnit.Framework;

namespace UnitTests
{
    [TestFixture]
    public class LenTests
    {
        [Test]
        [TestCase("1FBB", "5F1B821FBB")]
        [TestCase("02", "6002")]
        [TestCase("08", "9908")]
        public void Extract_Len_from_BER_TLV(string exc, string berTvl)
        {
            Assert.AreEqual(
                    exc,
                    new Hex(
                        new Len(
                            new BinaryHex(berTvl)
                        )
                    ).ToString()
                );
        }
    }
}
