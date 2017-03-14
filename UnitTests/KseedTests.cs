using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using HelloWord.Cryptography;

namespace UnitTests
{
    [TestClass]
    public class KseedTests
    {
        [TestMethod]
        public void Take_the_most_significant_16_bytes_to_form_the_Kseed()
        {
            Assert.AreEqual(
                    "239AB9CB282DAF66231DC5A4DF6BFBAE",
                    new Hex(
                        new KSeed(
                            new BinaryHex("239AB9CB282DAF66231DC5A4DF6BFBAEDF477565")
                        )
                    ).AsString()
                );
        }
    }
}
