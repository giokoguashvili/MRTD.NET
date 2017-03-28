using System;
using HelloWord.Infrastructure;
using HelloWord.ISO7816.CommandAPDU;
using HelloWord.ISO7816.CommandAPDU.Header;
using HelloWord.SecureMessaging;
using NUnit.Framework;
using UnitTests.FakeObjects;

namespace UnitTests
{
    [TestFixture]
    public class DO8ETests
    {
        [Test]
        public void Build_DO8E_with_SSC_apduHeader_DO87_KSmac()
        {
            //Assert.AreEqual(
            //        "8E08BF8B92D635FF24F8",
            //        new Hex(
            //            new BuildedDO8E(
            //                  new CC(
            //                      new N(
            //                          new BinaryHex("887022120C06C227"), // incrementedSSC
            //                          new M(
            //                              new ProtectedCommandApduHeader(
            //                                    new CommandApduHeader(
            //                                        new RawCommandApdu("00A4020C02011E")
            //                                    )
            //                               ),
            //                              new BinaryHex("8709016375432908C044F6") //do87
            //                          )
            //                      ),
            //                      new FkKSmac()
            //                  )
            //              )
            //        ).ToString()
            //    );
        }
    }
}
