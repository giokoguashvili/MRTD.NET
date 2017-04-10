using NUnit.Framework;
using SmartCardApi.Infrastructure;

namespace SmartCardApi.Cryptography
{
    [TestFixture]
    public class KmacTests
    {
        [Test]
        public void Calculate_the_basic_access_key_Kmac()
        {
            Assert.AreEqual(
                    "7962D9ECE03D1ACD4C76089DCE131543",
                    new Hex(
                        new Kmac(
                            new FkKSeed()
                        )
                    ).ToString()
                );
        }
    }
}
