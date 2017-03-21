using System;
using HelloWord.Cryptography;
using HelloWord.DataGroups;
using HelloWord.Infrastructure;
using HelloWord.SecureMessaging;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTests
{
    [TestClass]
    public class COMTests
    {
        [TestMethod]
        public void TestMethod1()
        {
            //Assert.AreEqual(
            //        "0CA4020C158709016375432908C044F68E08BF8B92D635FF24F800",
            //        new Hex(
            //            new COM(
            //                new KSenc(kSeedIc),
            //                new KSmac(kSeedIc),
            //                new IncrementedSSC(
            //                    new SSC(
            //                        rndIc,
            //                        rndIfd
            //                    )
            //                ),
            //                _reader
            //            )
            //        ).ToString()
            //    );
        }
    }
}
