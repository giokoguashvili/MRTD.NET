using NUnit.Framework;
using SmartCardApi.Cryptography;
using SmartCardApi.Infrastructure;

namespace SmartCardApi.SecureMessaging.CC
{
    [TestFixture]
    public class ComputedCCTests
    {
        [Test]
        [TestCase("BF8B92D635FF24F8", "887022120C06C227", "00A4020C02011E")]
        [TestCase("ED6705417E96BA55", "887022120C06C229", "00B0000004")]
        [TestCase("2EA28A70F3C7B535", "887022120C06C22B", "00B0000412")]
        public void ComputeCC_from_unprotectedCommandApdu(string exc, string incrementedSsc, string unprotectedCommandApdu)
        {
            Assert.AreEqual(
                    exc,
                    new Hex(
                        new ComputedCC(
                            new BinaryHex(incrementedSsc),
                            new FkKSenc(), 
                            new FkKSmac(), 
                            new BinaryHex(unprotectedCommandApdu)
                        )
                    ).ToString()
                );
        }
    }
}
