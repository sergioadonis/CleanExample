using CleanExample.Products.Entities;
using CleanExample.Products.UseCases.CreateProduct;
using CleanExample.Products.UseCases.CreateProduct.Models;
using CleanExample.Products.UseCases.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace CleanExample.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            // IoC Container
            using (var scope = SingletonFactory.CreateScope())
            {
                var product = new Product()
                {
                    Name = "Hola",
                    Id = "0"
                };                

                var createProduct = scope.ServiceProvider.GetService<UseCase>();
                var result = createProduct.Use(new InputModel()
                {
                    Product = product,
                    Trace = "123456-789"
                });
            }
            
            var use = SingletonFactory.GetService<UseCase>();
            var created = use.Use(new InputModel()
            {
                Product = new Product()
                {
                    Name = "Nuevo",
                    Description = "lakmsl"
                }
            });

            var logger = SingletonFactory.GetService<Common.Interfaces.Loggers.ILogger>();
            logger.Info("created", created);

            using (var scope = SingletonFactory.CreateScope())
            {
                var reposiotory = scope.ServiceProvider.GetService<IProductRepository>();
                var list = reposiotory.FindAll();
                System.Console.ReadLine();
            }
        }
    }
}
