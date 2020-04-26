using System;
using System.Collections.Generic;
using System.Linq;
using CleanExample.Core.Common.Entities;

namespace CleanExample.Test.Products.MockServices.Repositories
{
    public abstract class MockRepository<T> where T : AbstractEntity
    {
        protected static readonly List<T> Store = new List<T>();

        public bool Create(T entity)
        {
            var exists = Store.Exists(x => x.Id == entity.Id);
            if (exists)
                return false;

            Store.Add(entity);
            return true;
        }

        public bool Delete(Guid id)
        {
            var stored = Store.FirstOrDefault(x => x.Id == id);
            return stored != null && Store.Remove(stored);
        }

        public bool Update(T entity)
        {
            var index = Store.FindIndex(x => x.Id == entity.Id);
            if (index < 0)
                return false;

            Store.RemoveAt(index);
            Store.Insert(index, entity);

            return true;
        }

        public IEnumerable<T> FindAll()
        {
            return Store.ToList();
        }

        public T FindById(Guid id)
        {
            return Store.FirstOrDefault(x => x.Id == id);
        }
    }
}