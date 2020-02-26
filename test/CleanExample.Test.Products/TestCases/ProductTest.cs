using CleanExample.Core.Common.Exceptions;
using CleanExample.Core.Products.Entities;
using Xunit;

namespace CleanExample.Test.Products.TestCases
{
    public class ProductTest
    {
        [Fact]
        public void ProductNameIsEmptyTestCase()
        {
            Assert.Throws<NameIsEmptyException>(() => new Product(string.Empty));
        }

        [Fact]
        public void ProductNameTooLongTestCase()
        {
            var veryLongName = "The Product Name is Tooooooooooooooooooooooooooooooooooooooooooooooooooooooooo Loooooooooooong";
            Assert.Throws<NameIsTooLongException>(() => new Product(veryLongName));
        }

    }
}
