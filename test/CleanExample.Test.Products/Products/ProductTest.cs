using System;
using CleanExample.Core.Products.Products;
using Xunit;

namespace CleanExample.Test.Products.Products
{
    public class ProductTest
    {
        [Fact]
        public void ProductDescriptionNotNull()
        {
            var product = new Product("A Valid Name", null);
            Assert.NotNull(product.Description);
        }

        [Fact]
        public void ProductNameIsEmpty()
        {
            Assert.Throws<ArgumentNullException>(() => new Product(string.Empty));
        }

        [Fact]
        public void ProductNameTooLong()
        {
            const string veryLongName =
                "The Product Name is Tooooooooooooooooooooooooooooooooooooooooooooooooooooooooo Loooooooooooong";
            Assert.Throws<ArgumentException>(() => new Product(veryLongName));
        }
    }
}