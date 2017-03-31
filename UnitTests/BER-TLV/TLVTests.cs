using HelloWord;
using HelloWord.Infrastructure;
using NUnit.Framework;

namespace UnitTests
{
    [TestFixture]
    public class TLVTests
    {
        [Test]
        public void Parse_BER_TLV()
        {
            var parsedTvl = new BerTLV(
                                new BinaryHex("6F1A840E315041592E5359532E4444463031A5088801025F2D02656E")
                            );

            Assert.AreEqual(
                    "6F",
                    parsedTvl.Tag
                );
            Assert.AreEqual(
                    "840E315041592E5359532E4444463031A5088801025F2D02656E",
                    parsedTvl.Val
                );

            Assert.AreEqual(
                    "84",
                    parsedTvl.Data[0].Tag
                );
            Assert.AreEqual(
                    "315041592E5359532E4444463031",
                     parsedTvl.Data[0].Val
                );

            Assert.AreEqual(
                    "A5",
                    parsedTvl.Data[1].Tag
                );
            Assert.AreEqual(
                    "8801025F2D02656E",
                     parsedTvl.Data[1].Val
                );

            Assert.AreEqual(
                    "88",
                    parsedTvl.Data[1].Data[0].Tag
                );
            Assert.AreEqual(
                    "02",
                     parsedTvl.Data[1].Data[0].Val
                );

            Assert.AreEqual(
                    "5F2D",
                    parsedTvl.Data[1].Data[1].Tag
                );
            Assert.AreEqual(
                    "656E",
                     parsedTvl.Data[1].Data[1].Val
                );
        }

        //75 82 1FDA 7F

        [Test]
        public void Parse_BER_TLV_2()
        {
            var parsedTvl = new BerTLV(
                                new BinaryHex("75821FDA7F")
                            );

            Assert.AreEqual(
                    "75",
                    parsedTvl.Tag
                );
            Assert.AreEqual(
                    "001FDA",
                    parsedTvl.Len
                );
            Assert.AreEqual(
                    "7F",
                    parsedTvl.Val
                );
        }
    }
}
