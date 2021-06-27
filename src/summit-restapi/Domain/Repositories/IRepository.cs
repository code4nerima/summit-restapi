using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CfjSummit.Domain.Repositories
{
    public interface IRepository<TEntity> : IQueryableRepository<TEntity>
    {
        IQueryable<TEntity> GetAllForUpdate();
        void Add(TEntity entity);
        void AddRange(IReadOnlyCollection<TEntity> entities);
        void Update(TEntity entity);
        void Remove(TEntity entity);
        void RemoveById(long id);
        ValueTask<int> SaveChangesAsync();
    }
}
