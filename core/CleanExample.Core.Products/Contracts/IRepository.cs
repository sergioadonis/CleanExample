using System;
using System.Collections.Generic;
using CleanExample.Core.Products.Entities;

namespace CleanExample.Core.Products.Contracts
{
    public interface IRepository<TEntity, in TKey> where TEntity : Entity<TKey> where TKey : IEquatable<TKey>
    {
        IEnumerable<TEntity> Find();

        TEntity Find(TKey key);

        bool Insert(TEntity entity);

        bool Update(TEntity entity);

        bool Delete(TKey key);
    }
}