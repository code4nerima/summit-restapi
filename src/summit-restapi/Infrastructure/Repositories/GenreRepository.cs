using CfjSummit.Domain.Models.Entities;
using CfjSummit.Domain.Repositories;
using CfjSummit.Infrastructure.Contexts;

namespace CfjSummit.Infrastructure.Repositories
{
    public class GenreRepository : Repository<Genre>, IGenreRepository
    {
        public GenreRepository(CfjContext context) : base(context)
        {
        }
    }
}
