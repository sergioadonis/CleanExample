using CleanExample.Products.Entities;
using System.Collections.Generic;
using System.Linq;

namespace CleanExample.Products.Interfaces.Repositories
{
    public class DefaultProductRepository : IProductRepository
    {
        private IQueryable<Product> store;

        public DefaultProductRepository(IQueryable<Product> store)
        {
            this.store = store;
        }

        public IEnumerable<Product> FindAll()
        {
            return store.ToList<Product>();
        }

        public Product FindById(string id)
        {
            return store.FirstOrDefault(x => x.Id == id);
        }

        public Product FindByName(string name)
        {
            return store.FirstOrDefault(x => x.Name == name);
        }

        public Product Create(Product product)
        {
            product.Id = System.Guid.NewGuid().ToString();
            store.Append(product);
            return product;
        }

        public bool Update(Product product)
        {
            var stored = store.FirstOrDefault(x => x.Id == product.Id);
            if (stored != null)
            {
                stored = product;
                return true;
            }

            return false;
        }

        public bool Delete(string id)
        {
            var stored = store.FirstOrDefault(x => x.Id == id);
            if (stored != null)
            {
                store = store.Where(x => x.Id != id);
                return true;
            }

            return false;
        }
    }
}
