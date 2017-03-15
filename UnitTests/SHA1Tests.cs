using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using HelloWord.Cryptography;
using HelloWord;

namespace UnitTests
{
    [TestClass]
    public class SHA1Tests
    {
        [TestMethod]
        public void Calculate_the_SHA1_hash_of_MRZ_information()
        {
            Assert.AreEqual(
                    "239AB9CB282DAF66231DC5A4DF6BFBAEDF477565",
                    new Hex(
                        new SHA1(
                            new UTF8String("L898902C<369080619406236")
                        )
                    ).AsString()
                );
        }
    }
}
