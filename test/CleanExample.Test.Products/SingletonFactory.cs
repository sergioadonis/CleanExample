using CleanExample.Common.MockServices.Loggers;
using CleanExample.Common.MockServices.Time;
using CleanExample.Core.Common.Loggers;
using CleanExample.Core.Common.Time;
using CleanExample.Core.Products.Repositories;
using CleanExample.Core.Products.UseCases;
using CleanExample.Products.MockServices.Common.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace CleanExample.Test.Products
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
                    serviceCollection.AddScoped<CreateProductUseCase>();

                    serviceCollection.AddScoped<CreateProductTest>();
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
