using CfjSummit.Domain.Models.Entities;
using System.Threading.Tasks;

namespace CfjSummit.Domain.Repositories
{
    public interface IProgramRepository : IRepository<Program>
    {
        public ValueTask<Program> GetProgramWithOwnersAsync(string programId);
        public ValueTask<Program> GetProgramWithMembersAsync(string programId);
    }
}
