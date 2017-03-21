using System;
using HelloWord.Infrastructure;
using HelloWord.SecureMessaging;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void Construct_protected_APDU()
        {
            Assert.AreEqual(
                    "0CA4020C158709016375432908C044F68E08BF8B92D635FF24F800",
                    new Hex(
                        new ProtectedCommandApdu(
                            new BinaryHex("0CA4020C"), // apduHeader 
                            new BinaryHex("8E08BF8B92D635FF24F8"), //M
                            new BinaryHex("8709016375432908C044F6") //DO8E
                        )
                    ).ToString()
                );
        }
    }
}
