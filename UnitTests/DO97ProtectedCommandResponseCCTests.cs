using System;
using HelloWord.Infrastructure;
using HelloWord.SecureMessaging;
using HelloWord.SecureMessaging.DO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using UnitTests.FakeObjects;

namespace UnitTests
{
    [TestClass]
    public class DO97ProtectedCommandResponseCCTests
    {
        [TestMethod]
        public void Generate_CC_of_DO97ProtectedCommandResponseCC_with_kSmac_SSC()
        {
            var _DO97ProtectedCommandResponse = new BinaryHex("8709019FF0EC34F9922651990290008E08AD55CC17140B2DED9000"); //DO87ProtectedCommandResponse

            Assert.AreEqual(
                    "AD55CC17140B2DED",
                    new Hex(
                        new DO97ProtectedCommandResponseCC(
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
