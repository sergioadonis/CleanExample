using CleanExample.Common.MockServices.Repositories;
using CleanExample.Products.Entities;
using CleanExample.Products.Services.Common.Repositories;
using System.Linq;

namespace CleanExample.Products.MockServices.Common.Repositories
{
    public class ProductMockRepository : MockRepository<Product>, IProductRepository
    {
        public Product FindByName(string name)
        {
            return GetStore().FirstOrDefault(x => x.Name == name);
        }
    }
}
