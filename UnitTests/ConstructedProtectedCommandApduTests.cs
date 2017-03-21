using System;
using HelloWord.Infrastructure;
using HelloWord.SecureMessaging;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTests
{
    [TestClass]
    public class ConstructedProtectedCommandApduTests
    {
        [TestMethod]
        public void Construct_protected_APDU()
        {
            Assert.AreEqual(
                    "0CA4020C158709016375432908C044F68E08BF8B92D635FF24F800",
                    new Hex(
                        new ConstructedProtectedCommandApdu(
                            new BinaryHex("0CA4020C"), // apduHeader 
                            new BinaryHex("8709016375432908C044F6"), //DO87
                            new BinaryHex("8E08BF8B92D635FF24F8") //DO8E
                        )
                    ).ToString()
                );
        }
    }
}
