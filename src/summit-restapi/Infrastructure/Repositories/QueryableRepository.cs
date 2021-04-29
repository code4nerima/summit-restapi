using CfjSummit.Domain.Models.Entities;
using CfjSummit.Domain.Repositories;
using CfjSummit.Infrastructure.Contexts;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace CfjSummit.Infrastructure.Repositories
{
    public class QueryableRepository<TEntity> : IQueryableRepository<TEntity> where TEntity : Entity
    {
        protected readonly DbSet<TEntity> _table;

        public QueryableRepository(CfjContext context)
        {
            _table = context.Set<TEntity>();
        }

        public IQueryable<TEntity> GetAll() => _table.AsNoTracking();

        public TEntity GetById(long id) => _table.Find(id);
    }
}
