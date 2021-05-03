using CfjSummit.Domain.Models.Entities;
using CfjSummit.Domain.Repositories;
using CfjSummit.Infrastructure.Contexts;

namespace CfjSummit.Infrastructure.Repositories
{
    public class RequestLogRepository : Repository<RequestLog>, IRequestLogRepository
    {
        public RequestLogRepository(CfjContext context) : base(context)
        {

        }

    }
}
