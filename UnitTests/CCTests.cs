using System;
using HelloWord.Infrastructure;
using HelloWord.SecureMessaging;
using NUnit.Framework;
using NUnit.Framework;
using UnitTests.FakeObjects;
using Assert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;

namespace UnitTests
{
    [TestFixture]
    public class CCTests
    {
        //[Test]
        //public void Compute_MAC_over_N_with_KSmac()
        //{
        //    //http://stackoverflow.com/questions/30827140/epassport-problems-reagrding-mac-creation-in-icao-9303-worked-examples-in-java
        //    Assert.AreEqual(
        //            "BF8B92D635FF24F8",
        //            new Hex(
        //                new CC(
        //                    new BinaryHex("887022120C06C2270CA4020C800000008709016375432908C044F6"), // N - 80000000 without pad 
        //                    new BinaryHex("F1CB1F1FB5ADF208806B89DC579DC1F8") // KSmac
        //                )
        //            ).ToString()
        //        );
        //}

        //[Test]
        //public void Compute_MAC_over_K_with_KSmac()
        //{
        //    //http://stackoverflow.com/questions/30827140/epassport-problems-reagrding-mac-creation-in-icao-9303-worked-examples-in-java
        //    Assert.AreEqual(
        //            "FA855A5D4C50A8ED",
        //            new Hex(
        //                new CC(
        //                    new BinaryHex("887022120C06C22899029000"), // K - 80000000 without pad
        //                    new BinaryHex("F1CB1F1FB5ADF208806B89DC579DC1F8") // KSmac
        //                )
        //            ).ToString()
        //        );
        //}

        //[Test]
        //public void Compute_MAC_over_N_with_KSmac2()
        //{
        //    //http://stackoverflow.com/questions/30827140/epassport-problems-reagrding-mac-creation-in-icao-9303-worked-examples-in-java
        //    Assert.AreEqual(
        //            "ED6705417E96BA55",
        //            new Hex(
        //                new CC(
        //                    new BinaryHex("887022120C06C2290CB0000080000000970104"), // N - 80000000 without pad
        //                    new BinaryHex("F1CB1F1FB5ADF208806B89DC579DC1F8") // KSmac
        //                )
        //            ).ToString()
        //        );
        //}

        //[Test]
        //public void Compute_MAC_over_K_with_KSmac_from_DO97ProtectedCommandResponse()
        //{
        //    Assert.AreEqual(
        //            "AD55CC17140B2DED",
        //            new Hex(
        //                new CC(
        //                    new BinaryHex("887022120C06C22A8709019FF0EC34F992265199029000"), // K
        //                    new FkKSmac()// KSmac
        //                )
        //            ).ToString()
        //        );
        //}

        //[Test]
        //public void Compute_MAC_over_K_with_KSmac_from_DO97ProtectedCommandResponse2()
        //{
        //    Assert.AreEqual(
        //            "C8B2787EAEA07D74",
        //            new Hex(
        //                new CC(
        //                    new BinaryHex("887022120C06C22C871901FB9235F4E4037F2327DCC8964F1F9B8C30F42C8E2FFF224A99029000"), // K
        //                    new FkKSmac()// KSmac
        //                )
        //            ).ToString()
        //        );
        //}
    }
}
