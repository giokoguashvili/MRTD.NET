using System;
using HelloWord.Infrastructure;
using HelloWord.SecureMessaging;
using HelloWord.SecureMessaging.DO;
using HelloWord.SecureMessaging.ResponseDO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using UnitTests.FakeObjects;

namespace UnitTests
{
    [TestClass]
    public class DO8797ProtectedCommandResponseCCTests
    {
        [TestMethod]
        public void Generate_CC_of_DO87ProtectedCommandResponse_with_kSmac_SSC()
        {
            Assert.AreEqual(
                    "FA855A5D4C50A8ED",
                    new Hex(
                        new DO8797ProtectedCommandResponseCC(
                            new BinaryHex("887022120C06C228"), // incrementedSSC 
                            new FkKSmac(),
                            new DO87ProtectedCommandResponseDO99(
                                new BinaryHex("990290008E08FA855A5D4C50A8ED9000") //DO87ProtectedCommandResponse
                            )
                        )
                    ).ToString()
                );
        }


        [TestMethod]
        public void Generate_CC_of_DO97ProtectedCommandResponseCC_with_kSmac_SSC()
        {
            var _DO97ProtectedCommandResponse = new BinaryHex("8709019FF0EC34F9922651990290008E08AD55CC17140B2DED9000"); //DO87ProtectedCommandResponse

            Assert.AreEqual(
                    "AD55CC17140B2DED",
                    new Hex(
                        new DO8797ProtectedCommandResponseCC(
                            new BinaryHex("887022120C06C22A"), // incrementedSSC 
                            new FkKSmac(),
                            new DO97ProtectedCommandResponseDO87DO99(
                                _DO97ProtectedCommandResponse
                            )
                        )
                    ).ToString()
                );
        }
    }
}
