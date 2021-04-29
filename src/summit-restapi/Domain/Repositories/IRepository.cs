using System.Collections.Generic;

namespace CfjSummit.Domain.Repositories
{
    public interface IRepository<TEntity> : IQueryableRepository<TEntity>
    {
        void Add(TEntity entity);
        void AddRange(IReadOnlyCollection<TEntity> entities);
        void Update(TEntity entity);
        void Remove(TEntity entity);
        void RemoveById(long id);
    }
}
