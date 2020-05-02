using System.Collections.Generic;
using CleanExample.Core.Products.Entities;

namespace CleanExample.Core.Products.Contracts
{
    public interface IProductRepository : IRepository<Product, ProductKey>
    {
        Product FindByCodeOrName(BusinessKey businessKey, string code, string productName);

        IEnumerable<Product> FindByBusiness(BusinessKey businessKey);
    }
}