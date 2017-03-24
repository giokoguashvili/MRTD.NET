using System;
using NUnit.Framework;
using HelloWord.Cryptography.RandomKeys;
using UnitTests.FakeObjects;
using HelloWord.Cryptography;
using HelloWord.Infrastructure;
using HelloWord.SecureMessaging;

namespace UnitTests
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
