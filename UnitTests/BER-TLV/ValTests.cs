using System;
using HelloWord.BER_TLV;
using HelloWord.Infrastructure;
using NUnit.Framework;

namespace UnitTests.BER_TLV
{
    [TestFixture]
    public class ValTests
    {
        [Test]
        [TestCase("AABB", "5F1B02AABB")]
        [TestCase("BB", "5F1B01BB")]
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
