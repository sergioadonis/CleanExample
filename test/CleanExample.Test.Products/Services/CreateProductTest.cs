using System;
using System.Collections.Generic;
using CleanExample.Core.Products.Contracts;
using CleanExample.Core.Products.Dto;
using CleanExample.Core.Products.Entities;
using CleanExample.Core.Products.Exceptions;
using CleanExample.Core.Products.Services;
using CleanExample.Test.Products.Common;
using Microsoft.Extensions.DependencyInjection;
using Xunit;
using Xunit.Abstractions;

namespace CleanExample.Test.Products.Services
{
    public class CreateProductTest
    {
        public CreateProductTest(ITestOutputHelper output)
        {
            ILogger logger = new TestOutputLogger(output);

            var business = new Business("B1", "My Business");
            IBusinessRepository businessRepository = new InMemoryBusinessRepository(new List<Business>() {business});

            var products = new List<Product>
            {
                new Product("P01", business.Key, "My Product")
            };
            IProductRepository productRepository = new InMemoryProductRepository(products);

            var collection = new ServiceCollection()
                .AddScoped(sp => logger)
                .AddScoped(sp => productRepository)
                .AddScoped(sp => businessRepository)
                .AddScoped<CreateProduct>();

            _serviceProvider = collection.BuildServiceProvider();
            // _factory = _serviceProvider.GetRequiredService<IServiceScopeFactory>();
        }

        private readonly IServiceProvider _serviceProvider;

        [Fact]
        public void BusinessDoesNotExists()
        {
            var service = _serviceProvider.GetService<CreateProduct>();
            var input = new ProductDto()
            {
                BusinessCode = "TEST",
                ProductCode = "01",
                ProductName = "The Product Name"
            };
            Assert.Throws<BusinessDoesNotExists>(() => service.Invoke(input));
        }

        [Fact]
        public void ProductAlreadyExists()
        {
            var service = _serviceProvider.GetService<CreateProduct>();
            // var service = _factory.CreateScope().ServiceProvider.GetService<CreateProductService>();
            var input = new ProductDto()
            {
                BusinessCode = "B1",
                ProductCode = "P01",
                ProductName = "Other Product Name"
            };

            // Create product again to get exception
            Assert.Throws<ProductAlreadyExists>(() => service.Invoke(input));
        }
        // private readonly IServiceScopeFactory _factory;

        [Fact]
        public void ProductCreated()
        {
            var service = _serviceProvider.GetService<CreateProduct>();
            // var service = _factory.CreateScope().ServiceProvider.GetService<CreateProductService>();
            var input = new ProductDto()
            {
                BusinessCode = "B1",
                ProductCode = "P02",
                ProductName = "The Product Name2"
            };
            var output = service.Invoke(input);
            Assert.True(output.Created);
        }

        [Fact]
        public void ProductNameAlreadyExists()
        {
            var service = _serviceProvider.GetService<CreateProduct>();
            // var service = _factory.CreateScope().ServiceProvider.GetService<CreateProductService>();
            var input = new ProductDto()
            {
                BusinessCode = "B1",
                ProductCode = "P02",
                ProductName = "My Product"
            };

            // Create product again to get exception
            Assert.Throws<ProductAlreadyExists>(() => service.Invoke(input));
        }
    }
}