using System;
using System.Collections.Generic;
using CleanExample.Core.Products.Common;
using CleanExample.Core.Products.Products;
using CleanExample.Test.Products.Common;
using Microsoft.Extensions.DependencyInjection;
using Xunit;
using Xunit.Abstractions;

namespace CleanExample.Test.Products.Products
{
    public class GetProductsTest
    {
        public GetProductsTest(ITestOutputHelper output)
        {
            ILogger logger = new TestOutputLogger(output);
            IProductRepository repository = new InMemoryProductRepository(_products);

            var collection = new ServiceCollection()
                .AddScoped(sp => logger)
                .AddScoped(sp => repository)
                .AddScoped<GetProducts>();

            _serviceProvider = collection.BuildServiceProvider();
            // _factory = _serviceProvider.GetRequiredService<IServiceScopeFactory>();
        }

        private readonly ServiceProvider _serviceProvider;

        private readonly List<Product> _products = new List<Product>
        {
            new Product(Guid.NewGuid(), "Product One"),
            new Product(Guid.NewGuid(), "Product Two"),
            new Product(Guid.NewGuid(), "Product Three", "With description")
        };

        [Fact]
        public void ProductsIsNotEmpty()
        {
            var service = _serviceProvider.GetService<GetProducts>();
            var output = service.Invoke();
            // Assert.Equal(_products, output.Products);
            Assert.NotEmpty(output.Products);
        }
    }
}