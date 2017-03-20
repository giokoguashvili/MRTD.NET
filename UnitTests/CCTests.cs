using System;
using HelloWord.Infrastructure;
using HelloWord.SecureMessaging;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTests
{
    [TestClass]
    public class CCTests
    {
        [TestMethod]
        public void Compute_MAC_over_N_with_KSmac()
        {
            Assert.AreEqual(
                    "BF8B92D635FF24F8",
                    new Hex(
                        new CC(
                            new BinaryHex("887022120C06C2270CA4020C800000008709016375432908C044F68000000000"), // N 
                            new BinaryHex("F1CB1F1FB5ADF208806B89DC579DC1F8") // KSmac
                        )
                    ).ToString()
                );
        }

        [TestMethod]
        public void Compute_MAC_over_N_with_KSmac2()
        {
            Assert.AreEqual(
                    "ED6705417E96BA55",
                    new Hex(
                        new CC(
                            new BinaryHex("887022120C06C2290CB00000800000009701048000000000"), // N 
                            new BinaryHex("F1CB1F1FB5ADF208806B89DC579DC1F8") // KSmac
                        )
                    ).ToString()
                );
        }
    }
}
