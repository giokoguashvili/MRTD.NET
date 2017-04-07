using NUnit.Framework;
using SmartCardApi.Infrastructure;
using SmartCardApi.TVL.L;

namespace SmartCardApiTests
{
    [TestFixture]
    public class LenTests
    {
        [Test]
        [TestCase("821FBB", "5F1B821FBB")]
        [TestCase("02", "6002")]
        [TestCase("08", "9908")]
        [TestCase("821FDA", "75821FDA7F")]
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
