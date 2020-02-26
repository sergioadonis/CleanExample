using CleanExample.Core.Products.Entities;
using CleanExample.Core.Products.Repositories;
using System.Linq;

namespace CleanExample.Test.Products.MockServices.Repositories
{
    public class ProductMockRepository : MockRepository<Product>, IProductRepository
    {
        public Product FindByName(string name)
        {
            return GetStore().FirstOrDefault(x => x.Name == name);
        }
    }
}
