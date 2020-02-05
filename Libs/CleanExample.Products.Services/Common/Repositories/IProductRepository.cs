using CleanExample.Common.Services.Repositories;
using CleanExample.Products.Entities;
using System.Linq;

namespace CleanExample.Products.Services.Common.Repositories
{
    public interface IProductRepository : IRepository<Product>
    {
        Product FindByName(string name);
    }
}