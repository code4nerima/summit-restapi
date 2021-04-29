using CfjSummit.Domain.Models.Entities;
using CfjSummit.Domain.Repositories;
using CfjSummit.Infrastructure.Contexts;

namespace CfjSummit.Infrastructure.Repositories
{
    public class UserProfileRepository : Repository<UserProfile>, IUserProfileRepository
    {
        public UserProfileRepository(CfjContext context)
            : base(context)
        {

        }
    }
}
