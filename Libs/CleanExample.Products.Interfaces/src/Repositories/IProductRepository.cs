using System;
using CleanExample.Common.Interfaces.Repositories;
using CleanExample.Products.Entities;

namespace CleanExample.Products.Interfaces.Repositories
{
    public interface IProductRepository : IRepository<Product>
    {
        Product FindByName(string name);
    }
}