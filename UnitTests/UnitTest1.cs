using System;
using HelloWord.Infrastructure;
using HelloWord.SecureMessaging.CommandDO;
using HelloWord.SecureMessaging.DO;
using NUnit.Framework.Internal;
using NUnit.Framework;
using UnitTests.FakeObjects;
using DO87 = HelloWord.SecureMessaging.DO.DO87;

namespace UnitTests
{
    [TestFixture]
    public class UnitTest1
    {
        [Test]
        public void Build_DO97_from_UnprotectedCommandApdu()
        {
            Assert.AreEqual(
                    "8709016375432908C044F6",
                    new Hex(
                        new DO87(
                            new FkKSenc()
                        )
                        .FromUnprotectedCommand(new BinaryHex("00A4020C02011E"))
                    ).ToString()
                );
        }
    }
}
