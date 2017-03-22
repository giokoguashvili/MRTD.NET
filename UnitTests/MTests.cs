using System;
using HelloWord.Cryptography;
using HelloWord.Infrastructure;
using HelloWord.ISO7816.CommandAPDU;
using HelloWord.ISO7816.CommandAPDU.Body;
using HelloWord.ISO7816.CommandAPDU.Header;
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
                            new ProtectedCommandApduHeader(
                                new CommandApduHeader(rawCommandApdu)
                            ),
                            new DO87(
                                new EncryptedCommandApduData(
                                    new FkKSenc(), 
                                    new PadedCommandApduData(
                                        new CommandApduData(
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
