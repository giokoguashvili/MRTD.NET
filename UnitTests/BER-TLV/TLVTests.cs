using HelloWord.BER_TLV;
using HelloWord.Infrastructure;
using NUnit.Framework;
using System;

namespace UnitTests.BER_TLV
{
    [TestFixture]
    public class TLVTests
    {
        [Test]
        public void TestMethod1()
        {
            var parsetTvl = new BerTLV(
                                new BinaryHex("6F1A840E315041592E5359532E4444463031A5088801025F2D02656E")
                            );
            var data = parsetTvl.Data;
            Assert.Fail();
        }
    }
}
