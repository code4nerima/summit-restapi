using CfjSummit.Domain.Models.Entities;
using CfjSummit.Domain.Repositories;
using CfjSummit.Infrastructure.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CfjSummit.Infrastructure.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : Entity
    {
        protected readonly DbContext _db;
        protected readonly DbSet<TEntity> _table;
        public Repository(CfjContext context)
        {
            _db = context;
            _table = _db.Set<TEntity>();
        }
        public void Add(TEntity entity)
        {
            entity.SetForInsert("aaa", DateTime.UtcNow);
            _table.Add(entity);
        }
        public void AddRange(IReadOnlyCollection<TEntity> entities)
        {
            entities.ToList().ForEach(x => Add(x));
        }

        public IQueryable<TEntity> GetAll() => _table.AsNoTracking();
        public TEntity GetById(long id) => _table.Find(id);
        public void Remove(TEntity entity) => _table.Remove(entity);

        public void RemoveById(long id)
        {
            var entity = GetById(id);
            _table.Remove(entity);
        }

        public async ValueTask<int> SaveChangesAsync() => await _db.SaveChangesAsync();
        public void Update(TEntity entity)
        {
            entity.SetForUpdate("aaa", DateTime.UtcNow);
            _table.Update(entity);
        }
    }
}
