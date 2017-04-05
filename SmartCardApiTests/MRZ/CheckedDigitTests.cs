using System;
using NUnit.Framework;
using SmartCardApi.MRZ;

namespace SmartCardApiTests.MRZ
{
    [TestFixture]
    public class CheckedDigitTests
    {
        [Test]
        [TestCase(7, "12IB34415")]
        [TestCase(0, "920616")]
        [TestCase(9, "221008")]
        public void Calculate_MRZ_Check_Digit(int exc, string mrzDataField)
        {
            Assert.AreEqual(
                    exc,
                    new CheckedDigit(mrzDataField).Value()
                );
        }
    }
}
