using CleanExample.Common.Services.Mocks.Repositories;
using CleanExample.Products.Entities;
using CleanExample.Products.Services.Common.Repositories;
using System.Linq;

namespace CleanExample.Products.Services.Mocks.Repositories
{
    public class ProductMockRepository : MockRepository<Product>, IProductRepository
    {
        public Product FindByName(string name)
        {
            return GetStore().FirstOrDefault(x => x.Name == name);
        }
    }
}
