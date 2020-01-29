using CleanExample.Common.Interfaces.Repositories;
using CleanExample.Products.Entities;

namespace CleanExample.Products.UseCases.Repositories
{
    public interface IProductRepository : IRepository<Product>
    {
        Product FindByName(string name);
    }
}