using System;
using HelloWord.Commands;
using HelloWord.Infrastructure;
using HelloWord.SecureMessaging;
using HelloWord.SecureMessaging.ResponseDO.DO97;
using NUnit.Framework;
using UnitTests.FakeObjects;

namespace UnitTests
{
    [TestFixture]
    public class DO97ProtectedCommandApduTests
    {
        [Test]
        public void Generate_DO97_protected_APDU0()
        {
            Assert.AreEqual(
                    "0CB000000D9701048E08ED6705417E96BA5500",
                    new Hex(
                        new DO97ProtectedCommandApdu(
                            new ReadBinaryCommand(4),
                            new FkKSenc(),
                            new FkKSmac(),
                            new IncrementedSSC(new FkSSC()).By(3)
                        )
                    ).ToString()
                );
        }

        [Test]
        public void Generate_DO97_protected_APDU1()
        {
            Assert.AreEqual(
                    "0CB000040D9701128E082EA28A70F3C7B53500",
                    new Hex(
                        new DO97ProtectedCommandApdu(
                            new ReadBinaryCommand(0x04, 18),
                            new FkKSenc(),
                            new FkKSmac(),
                            new BinaryHex("887022120C06C22B") // IncrementedSSC
                        )
                    ).ToString()
                );
        }

    }
}
