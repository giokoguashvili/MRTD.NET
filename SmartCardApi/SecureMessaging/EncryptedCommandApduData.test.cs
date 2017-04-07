using NUnit.Framework;
using SmartCardApi.Infrastructure;
using SmartCardApi.SecureMessaging;
using SmartCardApiTests.FakeObjects;

namespace SmartCardApiTests
{
    [TestFixture]
    public class EncryptedDataTests
    {
        [Test]
        public void Encrypt_command_data_with_KSEnc()
        {
            Assert.AreEqual(
                    "6375432908C044F6",
                    new Hex(
                        new EncryptedCommandApduData(
                            new FkKSenc(),
                            new BinaryHex("011E800000000000")
                        )
                    ).ToString()
                );
        }
    }
}
