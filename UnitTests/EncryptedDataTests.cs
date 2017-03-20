using System;
using HelloWord.Cryptography;
using HelloWord.SecureMessaging;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using UnitTests.FakeObjects;

namespace UnitTests
{
    [TestClass]
    public class EncryptedDataTests
    {
        [TestMethod]
        public void Encrypt_command_data_with_KSEnc()
        {
            Assert.AreEqual(
                    "6375432908C044F6",
                    new Hex(
                        new EncryptedCommandData(
                            new FkKSenc(),
                            new BinaryHex("011E800000000000")
                        )
                    ).ToString()
                );
        }
    }
}
