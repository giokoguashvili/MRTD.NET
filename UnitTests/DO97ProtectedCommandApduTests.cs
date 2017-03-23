using System;
using HelloWord.Commands;
using HelloWord.Infrastructure;
using HelloWord.SecureMessaging;
using HelloWord.SecureMessaging.ResponseDO.DO97;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using UnitTests.FakeObjects;

namespace UnitTests
{
    [TestClass]
    public class DO97ProtectedCommandApduTests
    {
        [TestMethod]
        public void Generate_DO97_protected_APDU0()
        {
            Assert.AreEqual(
                    "0CB000000D9701048E08ED6705417E96BA5500",
                    new Hex(
                        new DO97ProtectedCommandApdu(
                            new ReadBinaryCommand(4),
                            new FkKSenc(),
                            new FkKSmac(),
                            new IncrementedSSC(
                                new IncrementedSSC(
                                    new IncrementedSSC(
                                        new FkSSC()
                                    )
                                )
                            )
                        )
                    ).ToString()
                );
        }

    }
}
