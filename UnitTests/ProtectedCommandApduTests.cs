using System;
using HelloWord.CommandAPDU;
using HelloWord.CommandAPDU.Header;
using HelloWord.Cryptography;
using HelloWord.Infrastructure;
using HelloWord.SecureMessaging;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using UnitTests.FakeObjects;

namespace UnitTests
{
    [TestClass]
    public class ProtectedCommandApduTests
    {
        [TestMethod]
        public void Generate_protected_APDU()
        {
            Assert.AreEqual(
                    "0CA4020C158709016375432908C044F68E08BF8B92D635FF24F800",
                    new Hex(
                        new ProtectedCommandApdu(
                            new RawCommandApdu("00A4020C02011E"),
                            new FkKSenc(),
                            new FkKSmac(),
                            new IncrementedSSC(
                                new FkSSC()
                            )
                        )
                    ).ToString()
                );
        }
    }
}
