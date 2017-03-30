using System;
using HelloWord.BER_TLV;
using HelloWord.Infrastructure;
using NUnit.Framework;

namespace UnitTests.BER_TLV
{
    [TestFixture]
    public class TagTests
    {
        [Test]
        public void Extract_BER_Tag()
        {
            Assert.AreEqual(
                    "5F0E",
                    new Hex(
                        new Tag(
                            new BinaryHex("5F0E2727")
                        )
                    ).ToString()
                );
        }
    }
}
