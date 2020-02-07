using CleanExample.Products.Entities;
using CleanExample.Products.Services.Common.Exceptions;
using CleanExample.Products.Services.CreateProduct;
using CleanExample.Products.Services.CreateProduct.Models;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace CleanExample.Products.Services.Test.CreateProduct
{
    public class UseCaseUnitTest
    {
        private UseCase useCase;
        private InputModel input;

        public UseCaseUnitTest()
        {
            useCase = SingletonFactory.ServiceProvider.GetService<UseCase>();
            input = new InputModel() { Product = new Product() };
        }

        [Fact]
        public void IsValidTestCase()
        {
            input.Product.Name = "The Product Name";
            Assert.True(useCase.Use(input).IsValid);
        }

        [Fact]
        public void ProductNameIsEmptyTestCase()
        {
            input.Product.Name = string.Empty;
            Assert.Throws<ProductNameIsEmptyException>(() => useCase.Use(input));
        }

        [Fact]
        public void ProductNameTooLongTestCase()
        {
            input.Product.Name = "The Product Name is Tooooooooooooooooooooooooooooooooooooooooooooooooooooooooo Loooooooooooong";
            Assert.Throws<ProductNameIsTooLongException>(() => useCase.Use(input));
        }

        [Fact]
        public void ProductNameAlreadyExistsTestCase()
        {
            input.Product.Name = "Unique Name Please";
            var output = useCase.Use(input);
            if (output.IsValid)
            {
                // Create product again to get exception
                Assert.Throws<ProductNameAlreadyExistsException>(() => useCase.Use(input));
            }
        }
    }
}
