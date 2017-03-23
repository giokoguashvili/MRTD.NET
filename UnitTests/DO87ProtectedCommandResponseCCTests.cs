using System;
using HelloWord.Infrastructure;
using HelloWord.SecureMessaging;
using HelloWord.SecureMessaging.DO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using UnitTests.FakeObjects;

namespace UnitTests
{
    [TestClass]
    public class DO87ProtectedCommandResponseCCTests
    {
        [TestMethod]
        public void Generate_CC_of_DO87ProtectedCommandResponse_with_kSmac_SSC()
        {
            Assert.AreEqual(
                    "FA855A5D4C50A8ED",
                    new Hex(
                        new DO87ProtectedCommandResponseCC(
                            new BinaryHex("887022120C06C228"), // incrementedSSC 
                            new FkKSmac(),
                            new DO87ProtectedCommandResponseDO99(
                                new BinaryHex("990290008E08FA855A5D4C50A8ED9000") //DO87ProtectedCommandResponse
                            )
                        )
                    ).ToString()
                );
        }
    }
}
