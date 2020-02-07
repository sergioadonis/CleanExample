using CleanExample.MockServices.Common.Repositories;
using CleanExample.Core.Products.Entities;
using CleanExample.Core.Products.Repositories;
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
