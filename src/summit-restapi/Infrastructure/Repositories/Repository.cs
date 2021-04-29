using CfjSummit.Domain.Repositories;
using System;
using System.Collections.Generic;

namespace CfjSummit.Infrastructure.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity>
    {
        public Repository()
        {

        }
        public void Add(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public void AddRange(IReadOnlyCollection<TEntity> entities)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TEntity> GetAll()
        {
            throw new NotImplementedException();
        }

        public TEntity GetById()
        {
            throw new NotImplementedException();
        }

        public void Remove(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public void RemoveById(long id)
        {
            throw new NotImplementedException();
        }

        public void Update(TEntity entity)
        {
            throw new NotImplementedException();
        }
    }
}
