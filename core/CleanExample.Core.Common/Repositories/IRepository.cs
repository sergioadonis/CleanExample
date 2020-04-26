using System;
using System.Collections.Generic;
using CleanExample.Core.Common.Entities;

namespace CleanExample.Core.Common.Repositories
{
    public interface IRepository<TEntity> where TEntity : AbstractEntity
    {
        IEnumerable<TEntity> FindAll();

        TEntity FindById(Guid id);

        bool Create(TEntity entity);

        bool Update(TEntity entity);

        bool Delete(Guid id);
    }
}