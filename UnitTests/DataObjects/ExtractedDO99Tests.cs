using HelloWord.Infrastructure;
using HelloWord.SecureMessaging.DataObjects.Extracted;
using NUnit.Framework;

namespace UnitTests.DataObjects
{
    [TestFixture]
    public class ExtractedDO99Tests
    {
        [Test]
        [TestCase("99029000", "990290008E08FA855A5D4C50A8ED9000")]
        [TestCase("99029000", "8709019FF0EC34F9922651990290008E08AD55CC17140B2DED9000")]
        [TestCase("99029000", "871901FB9235F4E4037F2327DCC8964F1F9B8C30F42C8E2FFF224A990290008E08C8B2787EAEA07D749000")]
        public void Extract_DO99_from_protectedResponseApdu(string exc, string protectedResponseApdu)
        {
            Assert.AreEqual(
                    exc,
                    new Hex(
                        new ExtractedDO99(
                            new BinaryHex(protectedResponseApdu)
                        )
                    ).ToString()
                );
        }
    }
}
