using NUnit.Framework;
using SmartCardApi.Infrastructure;
using SmartCardApi.ISO7816.CommandAPDU;

namespace SmartCardApiTests.ISO7816
{
    [TestFixture]
    public class CommandHeaderTests
    {
        [Test]
        public void Extract_CLA_from_rawCommandAPDU()
        {
            Assert.AreEqual(
                    "00",
                    new Hex(
                        new CommandHeader(
                            new BinaryHex("00A4020C")
                        ).CLA()
                    ).ToString()
                );
        }
    }
}
