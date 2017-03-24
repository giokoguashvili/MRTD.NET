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
    public class DO87Tests
    {
        [Test]
        public void Build_DO87_from_UnprotectedCommandApdu()
        {
            Assert.AreEqual(
                    "8709016375432908C044F6",
                    new Hex(
                        new DO87(
                            new FkKSenc()
                        )
                        .FromUnprotectedCommandApdu(new BinaryHex("00A4020C02011E"))
                    ).ToString()
                );
        }

        [Test]
        public void Extract_DO87_from_ProtectedResponseApdu()
        {
            Assert.AreEqual(
                    "8709019FF0EC34F9922651",
                    new Hex(
                        new DO87(
                            new FkKSenc()
                        )
                        .FromProtectedResponseApdu(
                            new BinaryHex("8709019FF0EC34F9922651990290008E08AD55CC17140B2DED9000")
                        )
                    ).ToString()
                );
        }
    }
}
