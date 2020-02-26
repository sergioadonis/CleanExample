using CleanExample.Core.Products.Entities;
using CleanExample.Core.Products.Exceptions;
using CleanExample.Core.Products.Models;
using CleanExample.Core.Products.UseCases;
using Microsoft.Extensions.DependencyInjection;
using System;
using Xunit;

namespace CleanExample.Test.Products.TestCases
{
    public class CreateProductTest
    {
        private CreateProductUseCase useCase;
        private CreateProductInputModel input;

        public CreateProductTest()
        {
            useCase = SingletonFactory.ServiceProvider.GetService<CreateProductUseCase>();
            input = new CreateProductInputModel();
        }

        [Fact]
        public void IsValidTestCase()
        {
            input.Product = new Product("The Product Name");
            Assert.True(useCase.Use(input).IsValid);
        }
        
        [Fact]
        public void ProductNameAlreadyExistsTestCase()
        {
            input.Product = new Product("Unique Name Please");            
            var output = useCase.Use(input);
            if (output.IsValid)
            {
                // Create product again to get exception
                Assert.Throws<ProductNameAlreadyExistsException>(() => useCase.Use(input));
            }
        }
    }
}
