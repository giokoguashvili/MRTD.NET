using HelloWord;
using HelloWord.Infrastructure;
using HelloWord.TVL.T;
using NUnit.Framework;

namespace UnitTests
{
    [TestFixture]
    public class SubsequentBytesTests
    {
        [Test]
        public void Extract_SubsequentBytes_from_BER_Tag()
        {
            //http://stackoverflow.com/questions/42450105/parsing-magtek-emv-tlv
            Assert.AreEqual(
                    "818279",
                    new Hex(
                        new TagSubsequentBytes(
                            new BinaryHex("5F81827978")
                        )
                    ).ToString()
                );
        }
    }
}
