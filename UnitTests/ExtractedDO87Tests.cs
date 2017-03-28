using System;
using HelloWord.Infrastructure;
using HelloWord.SecureMessaging.DO.Extracted;
using NUnit.Framework;

namespace UnitTests
{
    [TestFixture]
    public class ExtractedDO87Tests
    {
        [Test]
        public void Extract_DO87_from_protectedResponseApdu()
        {
            Assert.AreEqual(
                    "8709019FF0EC34F9922651",
                    new Hex(
                        new ExtractedDO87(
                            new BinaryHex("8709019FF0EC34F9922651990290008E08AD55CC17140B2DED9000")
                        )
                    ).ToString()
                );
        }
    }
}
