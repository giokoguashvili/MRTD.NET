using System;
using HelloWord.Infrastructure;
using HelloWord.SecureMessaging;
using NUnit.Framework;

namespace UnitTests
{
    [TestFixture]
    public class IncrementedSSCTests
    {
        [Test]
        public void Increment_SSC_by_1()
        {
            Assert.AreEqual(
                    "887022120C06C227",
                    new Hex(
                        new IncrementedSSC(new BinaryHex("887022120C06C226")).By(1)
                    ).ToString()
                );
        }
    }
}
