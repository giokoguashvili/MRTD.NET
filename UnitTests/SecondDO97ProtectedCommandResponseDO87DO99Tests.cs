using System;
using HelloWord.Infrastructure;
using HelloWord.SecureMessaging.ResponseDO.DO97;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTests
{
    [TestClass]
    public class SecondDO97ProtectedCommandResponseDO87DO99Tests
    {
        [TestMethod]
        public void Generate_DO87DO99_from_SecondDO97ProtectedCommandResponseDO87DO99Response()
        {
            Assert.AreEqual(
                    "871901FB9235F4E4037F2327DCC8964F1F9B8C30F42C8E2FFF224A99029000",
                    new Hex(
                        new SecondDO97ProtectedCommandResponseDO87DO99(
                            new BinaryHex("871901FB9235F4E4037F2327DCC8964F1F9B8C30F42C8E2FFF224A990290008E08C8B2787EAEA07D749000")
                        )
                    ).ToString()
                );
        }
    }
}
