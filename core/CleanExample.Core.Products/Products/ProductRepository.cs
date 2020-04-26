using System;
using CleanExample.Core.Products.Common;

namespace CleanExample.Core.Products.Products
{
    public interface IProductRepository : IRepository<Product, Guid>
    {
        Product FindByName(string name);
    }
}