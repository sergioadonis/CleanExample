using System;
using System.Collections.Generic;
using System.Linq;
using CleanExample.Core.Products.Common;

namespace CleanExample.Test.Products.Common
{
    public abstract class InMemoryRepository<TEntity, TId> where TEntity : Identifiable<TId> where TId : IEquatable<TId>
    {
        protected static readonly List<TEntity> Store = new List<TEntity>();

        protected InMemoryRepository(IEnumerable<TEntity> initialList = null)
        {
            if (initialList != null)
                Store.AddRange(initialList);
        }

        public bool Insert(TEntity entity)
        {
            var exists = Store.Exists(x => x.Id.Equals(entity.Id));
            if (exists)
                return false;

            Store.Add(entity);
            return true;
        }

        public bool Delete(Guid id)
        {
            var stored = Store.FirstOrDefault(x => x.Id.Equals(id));
            return stored != null && Store.Remove(stored);
        }

        public bool Update(TEntity entity)
        {
            var index = Store.FindIndex(x => x.Id.Equals(entity.Id));
            if (index < 0)
                return false;

            Store.RemoveAt(index);
            Store.Insert(index, entity);

            return true;
        }

        public IEnumerable<TEntity> FindAll()
        {
            return Store.ToList();
        }

        public TEntity FindById(Guid id)
        {
            return Store.FirstOrDefault(x => x.Id.Equals(id));
        }
    }
}