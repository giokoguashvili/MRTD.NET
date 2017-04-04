using NUnit.Framework;
using SmartCardApi.Infrastructure;
using SmartCardApi.ISO7816.CommandAPDU.Header;
using SmartCardApi.SecureMessaging;

namespace SmartCardApiTests.SecureMessaging
{
    [TestFixture]
    public class ConstructedProtectedCommandApduTests
    {
        [Test]
        public void Construct_protected_APDU()
        {
            Assert.AreEqual(
                    "0CA4020C158709016375432908C044F68E08BF8B92D635FF24F800",
                    new Hex(
                        new ConstructedProtectedCommandApdu(
                            new MaskedCommandApduHeader(new CommandApduHeader(new BinaryHex("00A4020C02011E"))), // rawCommandApdu 
                            new BinaryHex("8709016375432908C044F6"), //DO87
                            new BinaryHex(""), //DO97
                            new BinaryHex("8E08BF8B92D635FF24F8") //DO8E
                        )
                    ).ToString()
                );
        }
    }
}
