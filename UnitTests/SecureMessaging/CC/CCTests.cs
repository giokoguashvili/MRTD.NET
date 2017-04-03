using HelloWord.Infrastructure;
using HelloWord.SecureMessaging;
using NUnit.Framework;
using UnitTests.FakeObjects;
using Assert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;

namespace UnitTests.SecureMessaging
{
    [TestFixture]
    public class CCTests
    {
        [Test]
        [TestCase("BF8B92D635FF24F8", "887022120C06C227", "0CA4020C800000008709016375432908C044F6")]
        [TestCase("ED6705417E96BA55", "887022120C06C229", "0CB0000080000000970104")]
        [TestCase("2EA28A70F3C7B535", "887022120C06C22B", "0CB0000480000000970112")]
        public void Compute_MAC_over_N_with_KSmac(string exc, string incrementedSSC, string m)
        {
            //http://stackoverflow.com/questions/30827140/epassport-problems-reagrding-mac-creation-in-icao-9303-worked-examples-in-java
            Assert.AreEqual(
                    exc,
                    new Hex(
                        new CC(
                            new BinaryHex(incrementedSSC), //_incrementedSsc,
                            new FkKSmac(), //_kSmac,
                            new BinaryHex(m) 
                        )
                    ).ToString()
                );
        }
    }
}
