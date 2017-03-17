using Microsoft.VisualStudio.TestTools.UnitTesting;
using HelloWord.Cryptography;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HelloWord.Infrastructure;
using UnitTests.FakeObjects;

namespace HelloWord.Cryptography.Tests
{
    [TestClass()]
    public class KSencTests
    {
        [TestMethod()]
        public void Calculate_session_key_KSenc_with_KSeedIc()
        {
            Assert.AreEqual(
                   "979EC13B1CBFE9DCD01AB0FED307EAE5",
                   new Hex(
                       new KSenc(
                           new BinaryHex("0036D272F5C350ACAC50C3F572D23600")
                       )
                   ).ToString()
               );
        }
    }
}