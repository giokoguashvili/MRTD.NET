using System;
using HelloWord.Infrastructure;
using HelloWord.SecureMessaging;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using Assert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;

namespace UnitTests
{
    [TestClass]
    public class CCTests
    {
        [TestMethod]
        public void Compute_MAC_over_N_with_KSmac()
        {
            //http://stackoverflow.com/questions/30827140/epassport-problems-reagrding-mac-creation-in-icao-9303-worked-examples-in-java
            Assert.AreEqual(
                    "BF8B92D635FF24F8",
                    new Hex(
                        new CC(
                            new BinaryHex("887022120C06C2270CA4020C800000008709016375432908C044F6"), // N - 80000000 without pad 
                            new BinaryHex("F1CB1F1FB5ADF208806B89DC579DC1F8") // KSmac
                        )
                    ).ToString()
                );
        }

        [TestMethod]
        public void Compute_MAC_over_K_with_KSmac()
        {
            //http://stackoverflow.com/questions/30827140/epassport-problems-reagrding-mac-creation-in-icao-9303-worked-examples-in-java
            Assert.AreEqual(
                    "FA855A5D4C50A8ED",
                    new Hex(
                        new CC(
                            new BinaryHex("887022120C06C22899029000"), // K - 80000000 without pad
                            new BinaryHex("F1CB1F1FB5ADF208806B89DC579DC1F8") // KSmac
                        )
                    ).ToString()
                );
        }
    }
}
