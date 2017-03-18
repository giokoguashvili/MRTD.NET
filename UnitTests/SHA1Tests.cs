using System;
using NUnit.Framework;
using HelloWord.Cryptography;
using HelloWord;
using HelloWord.Infrastructure;

namespace UnitTests
{
    [TestFixture]
    public class SHA1Tests
    {
        [Test]
        public void Calculate_the_SHA1_hash_of_MRZ_information()
        {
            Assert.AreEqual(
                    "239AB9CB282DAF66231DC5A4DF6BFBAEDF477565",
                    new Hex(
                        new SHA1(
                            new UTF8String("L898902C<369080619406236")
                        )
                    ).ToString()
                );
        }

        [Test]
        [TestCase("AB94FCEDF2664EDFB9B291F85D7F77F27F2F4A9D", "239AB9CB282DAF66231DC5A4DF6BFBAE00000001")]
        [TestCase("7862D9ECE03C1BCD4D77089DCF131442814EA70A", "239AB9CB282DAF66231DC5A4DF6BFBAE00000002")]
        public void Calculate_the_SHA1_hash_of_D(string excSHA1, string inputD)
        {
            Assert.AreEqual(
                    excSHA1,
                    new Hex(
                        new SHA1(
                            new BinaryHex(inputD)
                        )
                    ).ToString()
                );
        }
    }
}
