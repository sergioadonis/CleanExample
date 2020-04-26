using System.Linq;
using CleanExample.Core.Products.Entities;
using CleanExample.Core.Products.Repositories;

namespace CleanExample.Test.Products.MockServices.Repositories
{
    public class ProductMockRepository : MockRepository<Product>, IProductRepository
    {
        public Product FindByName(string name)
        {
            return Store.FirstOrDefault(x => x.Name == name);
        }
    }
}