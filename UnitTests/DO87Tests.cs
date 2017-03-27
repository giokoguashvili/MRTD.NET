using System;
using HelloWord.Cryptography;
using HelloWord.Infrastructure;
using HelloWord.SecureMessaging.DO;
using NUnit.Framework.Internal;
using NUnit.Framework;
using UnitTests.FakeObjects;
using DO87 = HelloWord.SecureMessaging.DO.DO87;

namespace UnitTests
{
    [TestFixture]
    public class DO87Tests
    {
        //[Test]
        //public void Build_DO87_from_UnprotectedCommandApdu()
        //{
        //    Assert.AreEqual(
        //            "8709016375432908C044F6",
        //            new Hex(
        //                new DO87(
        //                    new FkKSenc()
        //                )
        //                .FromUnprotectedCommandApdu(new BinaryHex("00A4020C02011E"))
        //            ).ToString()
        //        );
        //}

        //[Test]
        //public void Extract_DO87_from_ProtectedResponseApdu()
        //{
        //    Assert.AreEqual(
        //            "8709019FF0EC34F9922651",
        //            new Hex(
        //                new DO87(
        //                    new FkKSenc()
        //                ).FromProtectedResponseApdu(
        //                    new BinaryHex("8709019FF0EC34F9922651990290008E08AD55CC17140B2DED9000")
        //                )
        //            ).ToString()
        //        );
        //}

        //[Test]
        //[TestCase(
        //        "60145F01",
        //        "8709019FF0EC34F9922651990290008E08AD55CC17140B2DED9000"
        //    )]
        //[TestCase(
        //        "04303130365F36063034303030305C026175",
        //        "871901FB9235F4E4037F2327DCC8964F1F9B8C30F42C8E2FFF224A990290008E08C8B2787EAEA07D749000"
        //    )]
        //public void Decrypt_DO87_Data_from_ProtectedResponseApdu(string act, string protectedResponseApdu)
        //{
        //    Assert.AreEqual(
        //            // add padding on protectedrResponseApdu decrypted data
        //            new Hex(new Padded(new BinaryHex(
        //                act                     
        //            ))).ToString(),
        //            new Hex(
        //                new DO87(
        //                    new FkKSenc()
        //                ).FromProtectedResponseApdu(
        //                    new BinaryHex(protectedResponseApdu)
        //                ).DecryptedData()
        //            ).ToString()
        //        );
        //}
    }
}
