using System.Linq;
using CleanExample.Core.Products.Products;
using CleanExample.Test.Products.Common.Repositories;

namespace CleanExample.Test.Products.Products
{
    public class InMemoryProductRepository : InMemoryRepository<Product>, IProductRepository
    {
        public Product FindByName(string name)
        {
            return Store.FirstOrDefault(x => x.Name == name);
        }
    }
}