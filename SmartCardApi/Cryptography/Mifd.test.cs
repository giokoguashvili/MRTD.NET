using NUnit.Framework;
using SmartCardApi.Cryptography;
using SmartCardApi.Infrastructure;
using SmartCardApiTests.FakeObjects;

namespace SmartCardApiTests.Cryptography
{
    [TestFixture]
    public class MifdTests
    {
        [Test]
        public void Mifd_generation_from_Eifd_Kmac_with_MAC3()
        {
            Assert.AreEqual(
                    "5F1448EEA8AD90A7",
                    new Hex(
                        new Mifd(
                            new FkEifd(),
                            new FkKmac()
                        )           
                    ).ToString()
                );
        }
    }
}
