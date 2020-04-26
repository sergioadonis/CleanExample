using System;
using CleanExample.Core.Products.Common;
using CleanExample.Core.Products.Products;
using CleanExample.Test.Products.Common;
using Microsoft.Extensions.DependencyInjection;
using Xunit;
using Xunit.Abstractions;

namespace CleanExample.Test.Products.Products
{
    public class CreateProductTest
    {
        public CreateProductTest(ITestOutputHelper output)
        {
            ILogger logger = new TestOutputLogger(output);
            var collection = new ServiceCollection()
                .AddScoped(sp => logger)
                .AddScoped<IProductRepository, InMemoryProductRepository>()
                .AddScoped<CreateProduct>();

            _serviceProvider = collection.BuildServiceProvider();
            // _factory = _serviceProvider.GetRequiredService<IServiceScopeFactory>();
        }

        private readonly IServiceProvider _serviceProvider;
        // private readonly IServiceScopeFactory _factory;

        [Fact]
        public void CreatedTestCase()
        {
            var service = _serviceProvider.GetService<CreateProduct>();
            // var service = _factory.CreateScope().ServiceProvider.GetService<CreateProductService>();
            var input = new CreateProduct.Input()
            {
                Name = "The Product Name2"
            };
            Assert.True(service.Invoke(input).Created);
        }

        [Fact]
        public void ProductNameAlreadyExistsTestCase()
        {
            var service = _serviceProvider.GetService<CreateProduct>();
            // var service = _factory.CreateScope().ServiceProvider.GetService<CreateProductService>();
            var input = new CreateProduct.Input()
            {
                Name = "Unique Name Please"
            };

            var output = service.Invoke(input);
            if (output.Created)
            {
                // Create product again to get exception
                Assert.Throws<ProductNameAlreadyExists>(() => service.Invoke(input));
            }
        }
    }
}