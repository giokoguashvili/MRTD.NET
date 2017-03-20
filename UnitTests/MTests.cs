using System;
using HelloWord.CommandAPDU;
using HelloWord.CommandAPDU.Body;
using HelloWord.CommandAPDU.Header;
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
            var rawCommandApdu = new RawCommandApdu("00A4020C02011E");
            Assert.AreEqual(
                    "0CA4020C800000008709016375432908C044F6",
                    new Hex(
                        new M(
                            new ProtectedCommandHeader(
                                new CommandAPDUHeader(rawCommandApdu)
                            ),
                            new DO87(
                                new EncryptedCommandData(
                                    new FkKSenc(), 
                                    new PadedCommandData(
                                        new CommandData(
                                            new CommandApduBody(rawCommandApdu)
                                        )
                                    )
                                )
                            )
                        )
                    )
                    .ToString()
                );
        }
    }
}
