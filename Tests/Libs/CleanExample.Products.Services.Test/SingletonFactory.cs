using CleanExample.Common.Services.Loggers;
using CleanExample.Common.Services.Mocks.Loggers;
using CleanExample.Common.Services.Mocks.Time;
using CleanExample.Common.Services.Time;
using CleanExample.Products.Services.Common.Repositories;
using CleanExample.Products.Services.CreateProduct;
using CleanExample.Products.Services.Mocks.Repositories;
using CleanExample.Products.Services.Test.CreateProduct;
using Microsoft.Extensions.DependencyInjection;

namespace CleanExample.Products.Services.Test
{
    public static class SingletonFactory
    {
        private static ServiceCollection serviceCollection;
        private static ServiceProvider serviceProvider;
        private static IServiceScopeFactory serviceScopeFactory;

        public static ServiceCollection ServiceCollection
        {
            get
            {
                if (serviceCollection == null)
                {
                    serviceCollection = new ServiceCollection();

                    serviceCollection.AddScoped<ITime, MockTime>();
                    serviceCollection.AddScoped<ILogger, MockLogger>();
                    serviceCollection.AddScoped<IProductRepository, ProductMockRepository>();
                    serviceCollection.AddScoped<UseCase>();

                    serviceCollection.AddScoped<UseCaseUnitTest>();
                }

                return serviceCollection;
            }
        }

        public static ServiceProvider ServiceProvider
        {
            get
            {
                if (serviceProvider == null)
                {
                    serviceProvider = ServiceCollection.BuildServiceProvider();
                }

                return serviceProvider;
            }
        }

        public static IServiceScopeFactory ServiceScopeFactory
        {
            get
            {
                if (serviceScopeFactory == null)
                {
                    serviceScopeFactory = ServiceProvider.GetRequiredService<IServiceScopeFactory>();
                }

                return serviceScopeFactory;
            }
        }

        public static T GetService<T>()
        {
            return ServiceProvider.GetService<T>();
        }

        public static IServiceScope CreateScope()
        {
            return ServiceScopeFactory.CreateScope();
        }

    }
}
