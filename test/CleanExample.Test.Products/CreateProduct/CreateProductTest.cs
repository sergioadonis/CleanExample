using CleanExample.Core.Products.Entities;
using CleanExample.Core.Products.Exceptions;
using CleanExample.Core.Products.Models;
using CleanExample.Core.Products.UseCases;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace CleanExample.Test.Products
{
    public class CreateProductTest
    {
        private CreateProductUseCase useCase;
        private CreateProductInputModel input;

        public CreateProductTest()
        {
            useCase = SingletonFactory.ServiceProvider.GetService<CreateProductUseCase>();
            input = new CreateProductInputModel() { Product = new Product() };
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
