using System;
using System.Collections.Generic;
using System.Linq;
using CleanExample.Common.Interfaces.Loggers;
using CleanExample.Common.Interfaces.Time;
using CleanExample.Products.Entities;
using CleanExample.Products.Interfaces.Repositories;
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
            
            var store = new List<Product>().AsQueryable();
            
            var repository = new DefaultProductRepository(store);
            var logger = new ConsoleLogger("123456-789");
            var time = new CurrentTime();
            var createProduct = new UseCase(repository, time, logger);
            
            var result = createProduct.Use(new InputModel()
            {
                Product = product
            });
            
            logger.Info("result: " + result);
            
            repository.Delete(result.Product.Id);
            
            logger.Info(repository.FindAll());
        }
    }
}
