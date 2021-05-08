using CfjSummit.Domain.Models.Entities;
using CfjSummit.Domain.Repositories;
using CfjSummit.Infrastructure.Contexts;

namespace CfjSummit.Infrastructure.Repositories
{
    public class TrackRepository : Repository<Track>, ITrackRepository
    {
        public TrackRepository(CfjContext context) : base(context)
        {

        }
    }
}
