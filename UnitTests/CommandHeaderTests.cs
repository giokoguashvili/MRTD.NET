using System;
using HelloWord.Cryptography;
using HelloWord.Infrastructure;
using HelloWord.ISO7816.CommandAPDU;
using NUnit.Framework;

namespace UnitTests
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
