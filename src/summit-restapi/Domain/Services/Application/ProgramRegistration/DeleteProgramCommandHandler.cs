using CfjSummit.Domain.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CfjSummit.Domain.Services.Application.ProgramRegistration
{
    public class DeleteProgramCommandHandler : IRequestHandler<DeleteProgramCommand, int>
    {
        private readonly IProgramRepository _repository;

        public DeleteProgramCommandHandler(IProgramRepository repository)
        {
            _repository = repository;
        }

        public async Task<int> Handle(DeleteProgramCommand request, CancellationToken cancellationToken)
        {
            var p = _repository.GetAllForUpdate()
                               .Include(x => x.ProgramGenres)
                               .Include(x => x.ProgramLinks)
                               .Include(x => x.ProgramPresenters)
                               .Include(x => x.ProgramUserProfiles)
                               .Include(x => x.ProgramGrarecos)
                               .SingleOrDefault(x => x.ProgramGuid == request.ProgramId);
            if (p == null) { return 0; }
            p.RemoveChildItems();
            _repository.Remove(p);
            return await _repository.SaveChangesAsync();
        }
    }
}
