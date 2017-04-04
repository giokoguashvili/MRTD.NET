using NUnit.Framework;
using SmartCardApi.Commands;
using SmartCardApi.Cryptography;
using SmartCardApi.Infrastructure;
using SmartCardApi.SecureMessaging;
using SmartCardApiTests.FakeObjects;

namespace SmartCardApiTests.SecureMessaging
{
    [TestFixture]
    public class ProtectedCommandApduTests
    {
        [Test]
        [TestCase("0CA4020C158709016375432908C044F68E08BF8B92D635FF24F800", "00A4020C02011E", "887022120C06C227")]
        [TestCase("0CB000000D9701048E08ED6705417E96BA5500", "00B0000004", "887022120C06C229")]
        [TestCase("0CB000040D9701128E082EA28A70F3C7B53500", "00B0000412", "887022120C06C22B")]
        public void Generate_protected_APDU(string exc, string commandApdu, string incrementedSsc)
        {
            Assert.AreEqual(
                    exc,
                    new Hex(
                        new ProtectedCommandApdu(
                            new BinaryHex(commandApdu),
                            new FkKSenc(),
                            new FkKSmac(),
                            new BinaryHex(incrementedSsc)
                        )
                    ).ToString()
                );
        }

        [Test]
        public void Generate_protected_APDU2()
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
                        new ProtectedCommandApdu(
                            new SelectEFCOMApplicationCommandApdu(),
                            new FkKSenc(),
                            new KSmac(kSeedIc),
                            new IncrementedSSC(new SSC(
                                    rndIc,
                                    rndIfd
                            )).By(1)
                        )
                    ).ToString()
                );
        }
    }
}
