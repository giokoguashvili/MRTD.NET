using HelloWord.Cryptography;
using HelloWord.Infrastructure;
using NUnit.Framework;

namespace UnitTests
{
    [TestFixture]
    public class _3DESTests
    {
        [Test]
        [TestCase(
            "72C29C2371CC9BDB65B779B8E8D37B29ECC154AA56A8799FAE2F498F76ED92F2", 
            "781723860C06C2264608F919887022120B795240CB7049B01C19B33E32804F0B", 
            "AB94FDECF2674FDFB9B391F85D7F76F2"
        )]
        public void Encrypt_S_and_KIFD_with_3DES(string exc, string s, string kEnc)
        {
            Assert.AreEqual(
                    exc,
                    new Hex(
                        new TripleDES(
                            new BinaryHex(kEnc),
                            new BinaryHex(s)
                        ).Encrypted()
                    ).ToString()
            );
        }

        [Test]
        [TestCase(
           "4608F91988702212781723860C06C2260B4F80323EB3191CB04970CB4052790B",
           "46B9342A41396CD7386BF5803104D7CEDC122B9132139BAF2EEDC94EE178534F",
           "AB94FDECF2674FDFB9B391F85D7F76F2"
        )]
        [TestCase(
           "4608F91988702212781723860C06C2260B4F80323EB3191CB04970CB4052790B",
           "46B9342A41396CD7386BF5803104D7CEDC122B9132139BAF2EEDC94EE178534F",
           "AB94FDECF2674FDFB9B391F85D7F76F2"
        )]

        
        public void Decrypt_Eic_from_EXTERNAL_AUTHENTICATE_RespData_with_3DES(string exc, string eIc, string kEnc)
        {
            Assert.AreEqual(
                    exc,
                    new Hex(
                        new TripleDES(
                            new BinaryHex(kEnc),
                            new BinaryHex(eIc)
                        ).Decrypted()
                    ).ToString()
            );
        }
    }
}
