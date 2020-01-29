using Microsoft.Extensions.DependencyInjection;

namespace CleanExample.ConsoleApp
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

                    serviceCollection.AddScoped<Common.Interfaces.Time.ITime, Common.Interfaces.Time.CurrentTime>();
                    serviceCollection.AddScoped<Common.Interfaces.Loggers.ILogger, Loggers.ConsoleLogger>();
                    serviceCollection.AddScoped<Products.UseCases.Repositories.IProductRepository, Repositories.DefaultProductRepository>();
                    serviceCollection.AddScoped<Products.UseCases.CreateProduct.UseCase>();
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
