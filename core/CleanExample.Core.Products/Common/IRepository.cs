using System;
using System.Collections.Generic;

namespace CleanExample.Core.Products.Common
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