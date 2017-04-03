using HelloWord.Cryptography;
using HelloWord.Infrastructure;
using NUnit.Framework;

namespace UnitTests.Cryptography
{
    [TestFixture]
    public class AddedPaddingTests
    {
        
        [Test]
        [TestCase(
            "887022120C06C2270CA4020C800000008709016375432908C044F68000000000", 
            "887022120C06C2270CA4020C800000008709016375432908C044F6")]
        public void Add_padding_on_data(string act, string data)
        {
            Assert.AreEqual(
                    act,
                    new Hex(
                        new Padded(
                            new BinaryHex(data)
                        )
                    ).ToString()
                );
        }
    }
}
