using System.Collections.Generic;

namespace CfjSummit.Domain.Repositories
{
    public interface IQueryableRepository<TEntity>
    {
        TEntity GetById();
        IEnumerable<TEntity> GetAll();

    }
}
