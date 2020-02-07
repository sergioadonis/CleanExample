using CleanExample.Core.Common.Entities;
using System.Collections.Generic;

namespace CleanExample.Core.Common.Repositories
{
    public interface IRepository<TEntity> where TEntity : AbstractEntity
    {
        IEnumerable<TEntity> FindAll();

        TEntity FindById(string id);

        TEntity Create(TEntity entity);

        bool Update(TEntity entity);

        bool Delete(string id);
    }
}