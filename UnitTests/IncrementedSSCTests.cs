using System;
using HelloWord.Infrastructure;
using HelloWord.SecureMessaging;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTests
{
    [TestClass]
    public class IncrementedSSCTests
    {
        [TestMethod]
        public void Increment_SSC_by_1()
        {
            Assert.AreEqual(
                    "887022120C06C227",
                    new Hex(
                        new IncrementedSSC(new BinaryHex("887022120C06C226")).By(1)
                    ).ToString()
                );
        }
    }
}
