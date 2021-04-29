using CfjSummit.Domain.Repositories;
using System;
using System.Collections.Generic;

namespace CfjSummit.Infrastructure.Repositories
{
    public class QueryableRepository<TEntity> : IQueryableRepository<TEntity>
    {

        public IEnumerable<TEntity> GetAll()
        {
            throw new NotImplementedException();
        }

        public TEntity GetById()
        {
            throw new NotImplementedException();
        }
    }
}
