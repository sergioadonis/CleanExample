using CleanExample.Products.Entities;
using CleanExample.Products.Services.Common.Repositories;
using System.Collections.Generic;
using System.Linq;

namespace CleanExample.ConsoleApp.Repositories
{
    public class DefaultProductRepository : IProductRepository
    {
        static IList<Product> store;

        static IList<Product> GetStore()
        {
            if (store == null)
                store = new List<Product>();

            return store;
        }

        public IEnumerable<Product> FindAll()
        {
            return GetStore().ToList();
        }

        public Product FindById(string id)
        {
            return GetStore().FirstOrDefault(x => x.Id == id);
        }

        public Product FindByName(string name)
        {
            return GetStore().FirstOrDefault(x => x.Name == name);
        }

        public Product Create(Product product)
        {
            product.Id = System.Guid.NewGuid().ToString();
            GetStore().Add(product);
            return product;
        }

        public bool Update(Product product)
        {
            var stored = GetStore().FirstOrDefault(x => x.Id == product.Id);
            if (stored != null)
            {
                stored = product;
                return true;
            }

            return false;
        }

        public bool Delete(string id)
        {
            var stored = GetStore().FirstOrDefault(x => x.Id == id);
            if (stored != null)
            {
                return GetStore().Remove(stored);
            }

            return false;
        }
    }
}
