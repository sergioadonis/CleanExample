using System;
using System.Collections.Generic;
using System.Linq;
using CleanExample.Core.Products.Entities;

namespace CleanExample.Test.Products.Common
{
    public abstract class InMemoryRepository<TEntity, TKey> where TEntity : Entity<TKey> where TKey : IEquatable<TKey>
    {
        protected readonly List<TEntity> Store = new List<TEntity>();

        protected InMemoryRepository(IEnumerable<TEntity> initialList = null)
        {
            if (initialList != null)
                Store.AddRange(initialList);
        }

        public bool Insert(TEntity entity)
        {
            var exists = Store.Exists(x => x.Key.Equals(entity.Key));
            if (exists)
                return false;

            Store.Add(entity);
            return true;
        }

        public bool Delete(TKey key)
        {
            var stored = Store.FirstOrDefault(x => x.Key.Equals(key));
            return stored != null && Store.Remove(stored);
        }

        public bool Update(TEntity entity)
        {
            var index = Store.FindIndex(x => x.Key.Equals(entity.Key));
            if (index < 0)
                return false;

            Store.RemoveAt(index);
            Store.Insert(index, entity);

            return true;
        }

        public IEnumerable<TEntity> Find()
        {
            return Store.ToList();
        }

        public TEntity Find(TKey key)
        {
            return Store.FirstOrDefault(x => x.Key.Equals(key));
        }
    }
}