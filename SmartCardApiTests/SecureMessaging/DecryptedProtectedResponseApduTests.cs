using NUnit.Framework;
using SmartCardApi.Infrastructure;
using SmartCardApi.SecureMessaging;
using SmartCardApiTests.FakeObjects;

namespace SmartCardApiTests.SecureMessaging
{
    [TestFixture]
    public class DecryptedProtectedResponseApduTests
    {
        [Test]
        [TestCase(
                "60145F01",
                "8709019FF0EC34F9922651990290008E08AD55CC17140B2DED9000"
            )]
        [TestCase(
                "04303130365F36063034303030305C026175",
                "871901FB9235F4E4037F2327DCC8964F1F9B8C30F42C8E2FFF224A990290008E08C8B2787EAEA07D749000"
            )]
        public void Decrypt_DO87_Data_from_ProtectedResponseApdu(string act, string protectedResponseApdu)
        {
            NUnit.Framework.Assert.AreEqual(
                    // add padding on protectedrResponseApdu decrypted data
                    act,
                    new Hex(
                        new DecryptedProtectedResponseApdu(
                            new BinaryHex(protectedResponseApdu),
                            new FkKSenc()
                        )
                    ).ToString()
                );
        }
    }
}
