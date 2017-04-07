using NUnit.Framework;
using SmartCardApi.Infrastructure;
using SmartCardApi.SecureMessaging.DataObjects.Extracted;

namespace SmartCardApiTests.DataObjects
{
    [TestFixture]
    public class ExtractedDO87Tests
    {
        [Test]
        [TestCase("8709019FF0EC34F9922651", "8709019FF0EC34F9922651990290008E08AD55CC17140B2DED9000")]
        [TestCase("871901FB9235F4E4037F2327DCC8964F1F9B8C30F42C8E2FFF224A", "871901FB9235F4E4037F2327DCC8964F1F9B8C30F42C8E2FFF224A990290008E08C8B2787EAEA07D749000")]
        public void Extract_DO87_from_protectedResponseApdu(string exc, string protectedResponseApdu)
        {
            Assert.AreEqual(
                    exc,
                    new Hex(
                        new ExtractedDO87(
                            new BinaryHex(protectedResponseApdu)
                        )
                    ).ToString()
                );
        }
    }
}
