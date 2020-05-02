using CleanExample.Core.Products.Entities;

namespace CleanExample.Core.Products.Contracts
{
    public interface IBusinessRepository : IRepository<Business, BusinessKey>
    {
    }
}