using System;
using HelloWord.Cryptography;
using HelloWord.Infrastructure;
using NUnit.Framework;

namespace UnitTests
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
            var a = new BinaryHex("A");
            System.IO.MemoryStream out_Renamed = new System.IO.MemoryStream();
            out_Renamed.Write(a.Bytes(), 0, a.Bytes().Length);

            //var hex = new Hex().ToString();
            Assert.AreEqual(
                    act,
                    new Hex(
                        new PaddedData(
                            new BinaryHex(data)
                        )
                    ).ToString()
                );
        }
    }
}
