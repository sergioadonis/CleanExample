using CleanExample.Common.Services.Models;
using CleanExample.Products.Entities;
using CleanExample.Products.Services.Common.Exceptions;
using CleanExample.Products.Services.CreateProduct;
using CleanExample.Products.Services.CreateProduct.Models;
using Microsoft.Extensions.DependencyInjection;
using System;
using Xunit;

namespace CleanExample.Products.Services.Test.CreateProduct
{
    public class UseCaseUnitTest
    {
        private string productNameVeryLong = "Hola22222222222222222222222222222222222222222222222222222222222222222222222222222222222222222222";

        [Fact]
        public void NotNullTest()
        {
            var name = Guid.NewGuid().ToString();
            var output = CreateProduct(name);
            Assert.NotNull(output);
        }

        [Fact]
        public void EqualNameTest()
        {
            var name = Guid.NewGuid().ToString();
            var output = CreateProduct(name);
            Assert.Equal(name, output.Product.Name);
        }

        [Fact]
        public void ProductIdNotEmptyTest()
        {
            var name = Guid.NewGuid().ToString();
            var output = CreateProduct(name);
            Assert.NotSame(string.Empty, output.Product.Id);
        }

        [Fact]
        public void SuccessStatusTest()
        {
            var name = Guid.NewGuid().ToString();
            var output = CreateProduct(name);
            Assert.Equal(StatusCode.Success, output.Status);
        }

        [Fact]
        public void ProductNameIsEmptyTest()
        {
            try
            {
                var name = "";
                var output = CreateProduct(name);
            }
            catch (Exception e)
            {
                Assert.IsType<ProductNameIsEmptyException>(e);
            }
        }

        [Fact]
        public void ProductNameTooLongTest()
        {
            try
            {
                var name = productNameVeryLong;
                var output = CreateProduct(name);
            }
            catch (Exception e)
            {
                Assert.IsType<ProductNameIsTooLongException>(e);
            }
        }

        [Fact]
        public void ProductNameAlreadyExistsTest()
        {
            try
            {
                var name = Guid.NewGuid().ToString();
                CreateProduct(name);
                var output = CreateProduct(name);
            }
            catch (Exception e)
            {
                Assert.IsType<ProductNameAlreadyExistsException>(e);
            }
        }

        private OutputModel CreateProduct(string name)
        {
            // IoC Container
            using (var scope = SingletonFactory.CreateScope())
            {
                var product = new Product()
                {
                    Name = name,
                    Id = "0"
                };

                var createProduct = scope.ServiceProvider.GetService<UseCase>();
                return createProduct.Use(new InputModel()
                {
                    Product = product
                });
            }
        }
    }

}
