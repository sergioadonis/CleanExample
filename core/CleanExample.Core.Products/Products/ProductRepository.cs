using CleanExample.Core.Products.Business;
using CleanExample.Core.Products.Common;

namespace CleanExample.Core.Products.Products
{
    public interface IProductRepository : IRepository<Product, ProductId>
    {
        Product FindByCodeOrName(BusinessId businessId, string productCode, string productName);
    }
}