using HelloWord.Cryptography;
using HelloWord.Infrastructure;
using NUnit.Framework;

namespace UnitTests.Cryptography
{
    [TestFixture]
    public class KseedIcTests
    {
        [Test]
        [TestCase(
            "0036D272F5C350ACAC50C3F572D23600", 
            "0B795240CB7049B01C19B33E32804F0B", 
            "0B4F80323EB3191CB04970CB4052790B"
        )]
        public void Calculate_XOR_of_KIFD_and_KIC(string act, string kIfd, string kIc)
        {
            Assert.AreEqual(
                    act,
                    new Hex(
                        new KseedIc(
                            new BinaryHex(kIfd),
                            new BinaryHex(kIc)
                        )
                    ).ToString()
                );
        }
    }
}
