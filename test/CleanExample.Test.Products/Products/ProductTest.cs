using System;
using CleanExample.Core.Products.Products;
using Xunit;

namespace CleanExample.Test.Products.Products
{
    public class ProductTest
    {
        [Fact]
        public void ProductNameIsEmptyTestCase()
        {
            Assert.Throws<ArgumentNullException>(() => new Product(string.Empty));
        }

        [Fact]
        public void ProductNameTooLongTestCase()
        {
            const string veryLongName =
                "The Product Name is Tooooooooooooooooooooooooooooooooooooooooooooooooooooooooo Loooooooooooong";
            Assert.Throws<ArgumentException>(() => new Product(veryLongName));
        }
    }
}