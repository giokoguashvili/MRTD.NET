using System;
using HelloWord.Cryptography;
using HelloWord.Infrastructure;
using HelloWord.SecureMessaging;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using UnitTests.FakeObjects;

namespace UnitTests
{
    [TestClass]
    public class MTests
    {
        [TestMethod]
        public void Generate_M_Concatenate_CmdHeader_and_DO87()
        {
            var rawCommandData = new RawCommandAPDU("");
            Assert.AreEqual(
                    "0CA4020C800000008709016375432908C044F6",
                    new Hex(
                        new M(
                            new ProtectedCommandHeader(
                                new CommandHeader(
                                    new BinaryHex("00A4020C")
                                )
                            ),
                            new DO87(
                                new EncryptedCommandData(
                                    new FkKSenc(), 
                                    new PadedCommandData(new BinaryHex("011E"))
                                )
                            )
                        )
                    )
                    .ToString()
                );
        }
    }
}
