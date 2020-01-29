using CleanExample.Common.Interfaces.Time;
using CleanExample.ConsoleApp.Loggers;
using CleanExample.ConsoleApp.Repositories;
using CleanExample.Products.Entities;
using CleanExample.Products.UseCases.CreateProduct;
using CleanExample.Products.UseCases.CreateProduct.Models;

namespace CleanExample.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            // Console.WriteLine("Hello World!");
            var product = new Product()
            {
                Name = "Hola",
                Id = "0"
            };
            
            var repository = new DefaultProductRepository();
            var logger = new ConsoleLogger("123456-789");
            var time = new CurrentTime();
            var createProduct = new UseCase(repository, time, logger);

            var result = createProduct.Use(new InputModel()
            {
                Product = product
            });

            logger.Info("result: ", result);
            repository.Delete(result.Product.Id);
            logger.Info("List: ", repository.FindAll());

            System.Console.ReadLine();
        }
    }
}
