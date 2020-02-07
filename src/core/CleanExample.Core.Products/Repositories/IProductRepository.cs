using CleanExample.Core.Common.Repositories;
using CleanExample.Core.Products.Entities;

namespace CleanExample.Core.Products.Repositories
{
    public interface IProductRepository : IRepository<Product>
    {
        Product FindByName(string name);
    }
}