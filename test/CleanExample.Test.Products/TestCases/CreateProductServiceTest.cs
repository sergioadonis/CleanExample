using System;
using CleanExample.Core.Common.Loggers;
using CleanExample.Core.Products.Exceptions;
using CleanExample.Core.Products.Repositories;
using CleanExample.Core.Products.Services;
using CleanExample.Test.Products.MockServices.Loggers;
using CleanExample.Test.Products.MockServices.Repositories;
using Microsoft.Extensions.DependencyInjection;
using Xunit;
using Xunit.Abstractions;

namespace CleanExample.Test.Products.TestCases
{
    public class CreateProductServiceTest
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly IServiceScopeFactory _factory;

        public CreateProductServiceTest(ITestOutputHelper output)
        {
            ILogger logger = new TestOutputLogger(output);
            var collection = new ServiceCollection()
                .AddScoped(sp => logger)
                .AddScoped<IProductRepository, ProductMockRepository>()
                .AddScoped<CreateProductService>();

            _serviceProvider = collection.BuildServiceProvider();
            _factory = _serviceProvider.GetRequiredService<IServiceScopeFactory>();
        }

        [Fact]
        public void IsValidTestCase()
        {
            var service = _serviceProvider.GetService<CreateProductService>();
            // var service = _factory.CreateScope().ServiceProvider.GetService<CreateProductService>();
            var input = new CreateProductService.InputModel()
            {
                Name = "The Product Name2"
            };
            Assert.True(service.Invoke(input).Created);
        }

        [Fact]
        public void ProductNameAlreadyExistsTestCase()
        {
            var service = _serviceProvider.GetService<CreateProductService>();
            // var service = _factory.CreateScope().ServiceProvider.GetService<CreateProductService>();
            var input = new CreateProductService.InputModel()
            {
                Name = "Unique Name Please"
            };

            var output = service.Invoke(input);
            if (output.Created)
            {
                // Create product again to get exception
                Assert.Throws<ProductNameAlreadyExistsException>(() => service.Invoke(input));
            }
        }
    }
}