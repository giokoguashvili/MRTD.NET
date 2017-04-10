using NUnit.Framework;
using SmartCardApi.Infrastructure;

namespace SmartCardApi.Cryptography
{
    [TestFixture]
    public class EifdTests
    {
        [Test]
        public void Eifd_generation_from_S_Kenc_with_3DES()
        { 
            Assert.AreEqual(
                    "72C29C2371CC9BDB65B779B8E8D37B29ECC154AA56A8799FAE2F498F76ED92F2",
                    new Hex(
                        new Eifd(
                            new FkS(),
                            new FkKenc()
                        )
                    ).ToString()
                );
        }
    }
}
