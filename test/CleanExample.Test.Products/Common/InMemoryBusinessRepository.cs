using System.Collections.Generic;
using CleanExample.Core.Products.Contracts;
using CleanExample.Core.Products.Entities;

namespace CleanExample.Test.Products.Common
{
    public class InMemoryBusinessRepository : InMemoryRepository<Business, BusinessKey>, IBusinessRepository
    {
        public InMemoryBusinessRepository(IEnumerable<Business> initialList = null) : base(initialList)
        {
        }
    }
}