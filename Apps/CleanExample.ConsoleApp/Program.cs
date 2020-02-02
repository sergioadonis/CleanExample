using CleanExample.Products.Entities;
using CleanExample.Products.Services.CreateProduct.Models;
using CleanExample.Products.Services.CreateProduct;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace CleanExample.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            try
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
                        User = "sergioadonis"
                    });

                    var createProduct2 = scope.ServiceProvider.GetService<UseCase>();
                    var result2 = createProduct.Use(new InputModel()
                    {
                        Product = new Product()
                        {
                            Name = "Hola22222222222222222222222222222222222222222222222222222222222222222222222222222222222222222222",
                            Id = "0"
                        }
                    });
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            finally
            {

            }


            Console.ReadLine();


        }
    }
}
