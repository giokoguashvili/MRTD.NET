using NUnit.Framework;
using SmartCardApi.Cryptography;
using SmartCardApi.Infrastructure;

namespace SmartCardApiTests.Cryptography
{
    [TestFixture]
    public class KSencTests
    {
        [Test]
        public void Calculate_session_key_KSenc_with_KSeedIc()
        {
            Assert.AreEqual(
                   "979EC13B1CBFE9DCD01AB0FED307EAE5",
                   new Hex(
                       new KSenc(
                           new BinaryHex("0036D272F5C350ACAC50C3F572D23600")
                       )
                   ).ToString()
               );
        }
    }
}