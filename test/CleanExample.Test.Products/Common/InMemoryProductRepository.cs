using System.Collections.Generic;
using System.Linq;
using CleanExample.Core.Products.Contracts;
using CleanExample.Core.Products.Entities;

namespace CleanExample.Test.Products.Common
{
    public class InMemoryProductRepository : InMemoryRepository<Product, ProductKey>, IProductRepository
    {
        public InMemoryProductRepository(IEnumerable<Product> initialList = null) : base(initialList)
        {
        }

        public Product FindByCodeOrName(BusinessKey businessKey, string productCode, string productName)
        {
            return Store.FirstOrDefault(x =>
                x.BusinessKey.Equals(businessKey) && (x.Code == productCode || x.Name == productName));
        }

        public IEnumerable<Product> FindByBusiness(BusinessKey businessKey)
        {
            return Store.FindAll(x => x.BusinessKey.Equals(businessKey));
        }
    }
}