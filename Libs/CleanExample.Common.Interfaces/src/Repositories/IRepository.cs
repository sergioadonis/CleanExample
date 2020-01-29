using CleanExample.Common.Entities;
using System.Collections.Generic;

namespace CleanExample.Common.Interfaces.Repositories
{
    public interface IRepository<TEntity> where TEntity : IEntity
    {
        IEnumerable<TEntity> FindAll();

        TEntity FindById(string id);

        TEntity Create(TEntity entity);

        bool Update(TEntity entity);

        bool Delete(string id);
    }
}