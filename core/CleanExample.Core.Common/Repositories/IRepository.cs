using CleanExample.Core.Common.Entities;
using System;
using System.Collections.Generic;

namespace CleanExample.Core.Common.Repositories
{
    public interface IRepository<TEntity> where TEntity : AbstractEntity
    {
        IEnumerable<TEntity> FindAll();

        TEntity FindById(Guid id);

        TEntity Create(TEntity entity);

        bool Update(TEntity entity);

        bool Delete(Guid id);
    }
}