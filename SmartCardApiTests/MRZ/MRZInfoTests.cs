using System;
using NUnit.Framework.Internal;
using NUnit.Framework;
using SmartCardApi.Infrastructure;
using SmartCardApi.MRZ;

namespace SmartCardApiTests.Infrastructure
{
    [TestFixture]
    public class MRZInfoTests
    {
        [TestCase]
        public void Generate_MRZ_info()
        {
            Assert.AreEqual(
                    "12IB34415792061602210089",
                    new MRZInfo(
                        "12IB34415",
                        new DateTime(1992, 06, 16),
                        new DateTime(2022, 10, 08)
                    ).ToString()
                );
        }
    }
}
