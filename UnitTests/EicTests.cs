using System;
using HelloWord.Cryptography;
using HelloWord.Infrastructure;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTests
{
    [TestClass]
    public class EicTests
    {
        [TestMethod]
        [DataRow(
            "46B9342A41396CD7386BF5803104D7CEDC122B9132139BAF2EEDC94EE178534F", 
            "46B9342A41396CD7386BF5803104D7CEDC122B9132139BAF2EEDC94EE178534F2F2D235D074D7449"
            )]
        public void Extract_Eic_from_external_aut_resp_data(string act, string extAuthRespdata)
        {
            Assert.AreEqual(
                    act,
                    new Hex(
                        new Eic(
                            new BinaryHex(extAuthRespdata)
                        )
                    ).ToString()
                );
        }
    }
}
