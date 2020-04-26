using System;
using System.Linq;
using CleanExample.Core.Products.Products;
using CleanExample.Test.Products.Common;

namespace CleanExample.Test.Products.Products
{
    public class InMemoryProductRepository : InMemoryRepository<Product, Guid>, IProductRepository
    {
        public Product FindByName(string name)
        {
            return Store.FirstOrDefault(x => x.Name == name);
        }
    }
}