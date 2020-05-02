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
    public class GetProductsTest
    {
        public GetProductsTest(ITestOutputHelper output)
        {
            ILogger logger = new TestOutputLogger(output);

            var business1 = "BUSINESS-1";
            var business2 = "BUSINESS-2";
            var products = new List<Product>
            {
                new Product("01", business1, "Product One"),
                new Product("02", business1, "Product Two"),
                new Product("03", business1, "Product Three", "With description")
            };
            var business = new List<Business>()
            {
                new Business(business1, "My First Business"),
                new Business(business2, "My Second Business")
            };

            IProductRepository productRepository = new InMemoryProductRepository(products);
            IBusinessRepository businessRepository = new InMemoryBusinessRepository(business);

            var collection = new ServiceCollection()
                .AddScoped(sp => logger)
                .AddScoped(sp => productRepository)
                .AddScoped(sp => businessRepository)
                .AddScoped<GetProductsByBusiness>();

            _serviceProvider = collection.BuildServiceProvider();
            // _factory = _serviceProvider.GetRequiredService<IServiceScopeFactory>();
        }

        private readonly ServiceProvider _serviceProvider;

        [Fact]
        public void BusinessDoesNotExists()
        {
            var service = _serviceProvider.GetService<GetProductsByBusiness>();
            var input = new BusinessKeyDto() {Code = "BUSINESS-3"};
            Assert.Throws<BusinessDoesNotExists>(() => service.Invoke(input));
        }

        [Fact]
        public void ProductsIsEmpty()
        {
            var service = _serviceProvider.GetService<GetProductsByBusiness>();
            var input = new BusinessKeyDto() {Code = "BUSINESS-2"};
            var output = service.Invoke(input);
            Assert.Empty(output);
        }

        [Fact]
        public void ProductsIsNotEmpty()
        {
            var service = _serviceProvider.GetService<GetProductsByBusiness>();
            var input = new BusinessKeyDto() {Code = "BUSINESS-1"};
            var output = service.Invoke(input);
            Assert.NotEmpty(output);
        }
    }
}