using CleanExample.Core.Products.Common;

namespace CleanExample.Core.Products.Products
{
    public interface IProductRepository : IRepository<Product>
    {
        Product FindByName(string name);
    }
}