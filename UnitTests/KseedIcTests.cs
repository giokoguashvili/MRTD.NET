using System;
using HelloWord.Cryptography;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTests
{
    [TestClass]
    public class KseedIcTests
    {
        [TestMethod]
        [DataRow("0036D272F5C350ACAC50C3F572D23600x", "0B795240CB7049B01C19B33E32804F0B", "0B4F80323EB3191CB04970CB4052790B")]
        public void Calculate_XOR_of_KIFD_and_KIC(string act, string kIfd, string kIc)
        {
            Assert.AreEqual(
                    act,
                    new Hex(
                        new KseedIc(
                            new BinaryHex(kIfd),
                            new BinaryHex(kIc)
                        )
                    ).ToString()
                );
        }
    }
}
