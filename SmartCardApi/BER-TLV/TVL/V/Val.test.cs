using NUnit.Framework;
using SmartCardApi.Infrastructure;

namespace SmartCardApi.TVL.V
{
    [TestFixture]
    public class ValTests
    {
        [Test]
        [TestCase("AABB", "5F1B02AABB")]
        [TestCase("BB", "5F1B01BB")]
        [TestCase("7F", "758200017F")]
        public void Extract_Val_from_BER_TLV(string exc, string berTlv)
        {
            Assert.AreEqual(
                    exc,
                    new Hex(
                        new Val(
                            new BinaryHex(berTlv)
                        )
                    ).ToString()
                );
        }
    }
}
