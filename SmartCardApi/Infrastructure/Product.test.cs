using NUnit.Framework;

namespace SmartCardApi.Infrastructure
{
    [TestFixture]
    public class ProductTests
    {
        [TestCase]
        public void Product_of_two_numbers()
        {
            Assert.AreEqual(
                    12,
                    new Product(6, 2).Value()
                );
        }
    }
}
