using System;
using HelloWord.Infrastructure;
using HelloWord.SecureMessaging;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTests
{
    [TestClass]
    public class NTests
    {
        [TestMethod]
        public void Generate_N_Concatenate_SSC_and_M_and_add_padding()
        {
            Assert.AreEqual(
                    "887022120C06C2270CA4020C800000008709016375432908C044F68000000000",
                    new Hex(
                        new N(
                            new BinaryHex("887022120C06C227"), // SSC
                            new BinaryHex("0CA4020C800000008709016375432908C044F6") // M
                        )
                    ).ToString()
                );
        }
    }
}
