using NUnit.Framework;
using SmartCardApi.Cryptography;
using SmartCardApi.Infrastructure;
using SmartCardApiTests.FakeObjects;

namespace SmartCardApiTests.Cryptography
{
    [TestFixture]
    public class KencTests
    {
        [Test]
        public void Calculate_the_basic_access_key_Kenc()
        {
            Assert.AreEqual(
                    "AB94FDECF2674FDFB9B391F85D7F76F2",
                    new Hex(
                        new Kenc(
                            new FkKSeed()
                        )
                    ).ToString()
                );
        }

        [Test]
        [TestCase("AB94FDECF2674FDFB9B391F85D7F76F2", "L898902C<369080619406236")]
        public void Calculate_the_basic_access_key_Kenc_from_mrzInfo(string act, string mrzInfo)
        {
            Assert.AreEqual(
                    act,
                    new Hex(
                        new Kenc(mrzInfo)
                    ).ToString()
                );
        }
    }
}
