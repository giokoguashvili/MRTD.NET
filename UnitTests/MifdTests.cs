using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using HelloWord.Cryptography;
using UnitTests.FakeObjects;

namespace UnitTests
{
    [TestClass]
    public class MifdTests
    {
        [TestMethod]
        public void Mifd_generation_from_Eifd_Kmac_with_MAC3()
        {
            Assert.AreEqual(
                    "5F1448EEA8AD90A7",
                    new Hex(
                        new Mifd(
                            new FkEifd(),
                            new FkKmac()
                        )           
                    ).AsString()
                );
        }
    }
}
