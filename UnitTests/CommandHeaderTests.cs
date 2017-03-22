using System;
using HelloWord.Cryptography;
using HelloWord.Infrastructure;
using HelloWord.ISO7816.CommandAPDU;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTests
{
    [TestClass]
    public class CommandHeaderTests
    {
        [TestMethod]
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
