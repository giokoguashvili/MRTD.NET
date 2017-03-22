using HelloWord.Cryptography;
using HelloWord.Infrastructure;
using NUnit.Framework;

namespace UnitTests
{
    [TestFixture]
    public class KSmacTests
    {
        [Test]
        [TestCase("F1CB1F1FB5ADF208806B89DC579DC1F8", "0036D272F5C350ACAC50C3F572D23600")]
        public void Calculate_session_key_KSmac_with_KSeedIc(string act, string kSeedIc)
        {
            Assert.AreEqual(
                   act,
                   new Hex(
                       new KSmac(
                           new BinaryHex(kSeedIc)
                       )
                   ).ToString()
               );
        }
    }
}