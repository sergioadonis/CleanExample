using System.Collections.Generic;
using System.Linq;
using CleanExample.Core.Products.Business;
using CleanExample.Core.Products.Products;
using CleanExample.Test.Products.Common;

namespace CleanExample.Test.Products.Products
{
    public class InMemoryProductRepository : InMemoryRepository<Product, ProductId>, IProductRepository
    {
        public InMemoryProductRepository(IEnumerable<Product> initialList = null) : base(initialList)
        {
        }

        public Product FindByCodeOrName(BusinessId businessId, string productCode, string productName)
        {
            return Store.FirstOrDefault(x =>
                x.Id.BusinessId.Alias == businessId.Alias && (x.Id.Code == productCode || x.Name == productName));
        }
    }
}