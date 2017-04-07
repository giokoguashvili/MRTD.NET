using NUnit.Framework;
using SmartCardApi.Infrastructure;
using SmartCardApi.SecureMessaging.DataObjects.Builded;

namespace SmartCardApiTests.DataObjects
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
