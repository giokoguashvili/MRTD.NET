using System;
using HelloWord.Infrastructure;
using HelloWord.SecureMessaging.DataObjects.Builded;
using NUnit.Framework;
using NUnit.Framework.Internal;
using UnitTests.FakeObjects;

namespace UnitTests
{
    [TestFixture]
    public class BuildedDO8ETests
    {
        [Test]
        public void Build_DO8E()
        {
            Assert.AreEqual(
                    "8E08BF8B92D635FF24F8",
                    new Hex(
                        new BuildedDO8E(
                            new BinaryHex("00A4020C02011E"), // rawCommandApdu
                            new BinaryHex("887022120C06C227"), // incrementedSSC
                            new FkKSmac(), 
                            new FkKSenc()
                        )
                    ).ToString()
                );
        }
    }
}
