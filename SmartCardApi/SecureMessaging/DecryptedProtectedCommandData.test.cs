using NUnit.Framework;
using SmartCardApi.Cryptography;
using SmartCardApi.Infrastructure;

namespace SmartCardApi.SecureMessaging
{
    [TestFixture]
    public class DecryptedProtectedCommandDataTests
    {
        [Test]
        public void Decrypt_data_of_DO87_with_KSEnc_of_DO97ProtectedCmmandResponse()
        {
            //new Org.BouncyCastle.Asn1.DerOctetString()
            
            Assert.AreEqual(
                    "60145F0180000000", // Decrypted Data with padded data
                    new Hex(
                        new DecryptedProtectedCommandData(
                            new BinaryHex("9FF0EC34F9922651"),
                            new FkKSenc()
                        )
                    ).ToString()
                );
        }
    }
}
