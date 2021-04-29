using System.Linq;

namespace CfjSummit.Domain.Repositories
{
    public interface IQueryableRepository<TEntity>
    {
        TEntity GetById(long id);
        IQueryable<TEntity> GetAll();
    }
}
