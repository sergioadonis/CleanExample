using System.Collections.Generic;
using CleanExample.Core.Products.Business;
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

            var businessId = new BusinessId("TEST");
            var products = new List<Product>
            {
                new Product(businessId, "01", "Product One"),
                new Product(businessId, "02", "Product Two"),
                new Product(businessId, "03", "Product Three", "With description")
            };

            IProductRepository repository = new InMemoryProductRepository(products);

            var collection = new ServiceCollection()
                .AddScoped(sp => logger)
                .AddScoped(sp => repository)
                .AddScoped<GetProducts>();

            _serviceProvider = collection.BuildServiceProvider();
            // _factory = _serviceProvider.GetRequiredService<IServiceScopeFactory>();
        }

        private readonly ServiceProvider _serviceProvider;

        [Fact]
        public void ProductsIsNotEmpty()
        {
            var service = _serviceProvider.GetService<GetProducts>();
            var output = service.Invoke();
            Assert.NotEmpty(output);
        }
    }
}