using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using HelloWord.Cryptography;

namespace UnitTests
{
    [TestClass]
    public class _3DESTests
    {
        [TestMethod]
        [DataRow(
            "72C29C2371CC9BDB65B779B8E8D37B29ECC154AA56A8799FAE2F498F76ED92F2", 
            "781723860C06C2264608F919887022120B795240CB7049B01C19B33E32804F0B", 
            "AB94FDECF2674FDFB9B391F85D7F76F2"
        )]
        public void Encrypt_S_and_KIFD_with_3DES(string exc, string s, string kIFD)
        {
            Assert.AreEqual(
                    exc,
                    new Hex(
                        new TripleDES(
                            new BinaryHex(kIFD),
                            new BinaryHex(s)
                        )
                    ).AsString()
            );
        }
    }
}
