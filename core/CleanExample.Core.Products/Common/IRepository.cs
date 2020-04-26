using System.Collections.Generic;

namespace CleanExample.Core.Products.Common
{
    public interface IRepository<TEntity, in TId> where TEntity : Identifiable<TId>
    {
        IEnumerable<TEntity> FindAll();

        TEntity FindById(TId id);

        bool Create(TEntity entity);

        bool Update(TEntity entity);

        bool Delete(TId id);
    }
}