using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using HelloWord.Cryptography;
using UnitTests.FakeObjects;

namespace UnitTests
{
    [TestClass]
    public class ExternalAuthenticateCmdDataTests
    {
        [TestMethod]
        public void Generate_cmd_data_with_MIFD_and_EIFD()
        {
            Assert.AreEqual(
                    "72C29C2371CC9BDB65B779B8E8D37B29ECC154AA56A8799FAE2F498F76ED92F25F1448EEA8AD90A7",
                    new Hex(
                        new ExternalAuthenticateCmdData(
                            "L898902C<369080619406236",
                            new BinaryHex("4608F91988702212"),
                            new FkRNDifd(),
                            new FkKifd()
                        )
                    ).AsString()
                );
        }
    }
}
