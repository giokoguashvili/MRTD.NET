using NUnit.Framework;
using SmartCardApi.Infrastructure;
using SmartCardApi.SmartCard;

namespace SmartCardApiTests
{
    [TestFixture]
    public class DecryptedExternalAuthenticateResponseDataTests
    {
        [Test]
        [TestCase(
            "4608F91988702212781723860C06C2260B4F80323EB3191CB04970CB4052790B",
            "46B9342A41396CD7386BF5803104D7CEDC122B9132139BAF2EEDC94EE178534F2F2D235D074D7449",
            "L898902C<369080619406236"
        )]
        public void Decrypte_extAuthRespData_with_Kenc_and_Eic_and_MRZInfo(string act, string extAuthResData, string mrzInfo)
        {
            Assert.AreEqual(
                    act,
                    new Hex(
                        new DecryptedExternalAuthenticateResponseData(
                            new BinaryHex(extAuthResData),
                            mrzInfo
                        )
                    ).ToString() 
                );
        }
    }
}
