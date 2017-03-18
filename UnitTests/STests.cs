using System;
using NUnit.Framework;
using HelloWord.Cryptography.RandomKeys;
using UnitTests.FakeObjects;
using HelloWord.Cryptography;

namespace UnitTests
{
    [TestFixture]
    public class STests
    {
        [Test]
        public void Combine_RNDifd_RNDic_Kifd()
        {
            Assert.AreEqual(
                    "781723860C06C2264608F919887022120B795240CB7049B01C19B33E32804F0B",
                    new Hex(
                        new S(
                            new FkRNDifd(),
                            new FkRNDic(),
                            new FkKifd()
                        )
                    ).ToString()
                );
        }
    }
}
