using System;
using HelloWord.Commands;
using HelloWord.Cryptography;
using HelloWord.Infrastructure;
using HelloWord.SecureMessaging;
using HelloWord.SecureMessaging.ResponseDO.DO87;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using UnitTests.FakeObjects;

namespace UnitTests
{
    [TestClass]
    public class DO87ProtectedCommandApduTests
    {

        [TestMethod]
        public void Generate_DO87_protected_APDU()
        {
            Assert.AreEqual(
                    "0CA4020C158709016375432908C044F68E08BF8B92D635FF24F800",
                    new Hex(
                        new DO87ProtectedCommandApdu(
                            new SelectEFCOMApplicationCommand(),
                            new FkKSenc(),
                            new FkKSmac(),
                            new IncrementedSSC(new FkSSC()).By(1)
                        )
                    ).ToString()
                );
        }

        [TestMethod]
        public void Generate_DO87_protected_APDU2()
        {
            var kIfd = new BinaryHex("0B795240CB7049B01C19B33E32804F0B"); //new CachedBinary(new Kifd()));
            var rndIc = new FkRNDic(); //new CachedBinary(new RNDic(_reader));
            var rndIfd = new FkRNDifd(); //new CachedBinary(new RNDifd());
            var kSeedIc = new KseedIc(
                                kIfd,
                                new Kic(
                                    new R(
                                        new BinaryHex("46B9342A41396CD7386BF5803104D7CEDC122B9132139BAF2EEDC94EE178534F2F2D235D074D7449"), //exterbalAuthData
                                        "L898902C<369080619406236"
                                    )
                                )
                            );

            Assert.AreEqual(
                    "0CA4020C158709016375432908C044F68E08BF8B92D635FF24F800",
                    new Hex(
                        new DO87ProtectedCommandApdu(
                            new SelectEFCOMApplicationCommand(),
                            new KSenc(kSeedIc),
                            new KSmac(kSeedIc),
                            new IncrementedSSC(
                                new SSC(
                                    rndIc,
                                    rndIfd
                                )
                            ).By(1)
                        )
                    ).ToString()
                );
        }
    }
}
