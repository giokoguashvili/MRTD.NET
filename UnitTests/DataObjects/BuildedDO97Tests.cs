using System;
using HelloWord.Cryptography;
using HelloWord.Infrastructure;
using HelloWord.SecureMessaging;
using HelloWord.SecureMessaging.DataObjects.Builded;
using HelloWord.SecureMessaging.DataObjects.Extracted;
using NUnit.Framework.Internal;
using NUnit.Framework;
using UnitTests.FakeObjects;
using DO87 = HelloWord.SecureMessaging.DataObjects.DO.DO87;

namespace UnitTests
{
    [TestFixture]
    public class BuildedDO97Tests
    {
        [Test]
        [TestCase("970104", "00B0000004")]
        [TestCase("970112", "00B0000412")]
        public void Build_DO97_from_UnprotectedCommandApdu(string exc, string rawCommandApdu)
        {
            Assert.AreEqual(
                    exc,
                    new Hex(
                        new BuildedDO97(
                            new BinaryHex(rawCommandApdu) // rawCommandApdu 
                        )
                    ).ToString()
                );
        }
    }
}
