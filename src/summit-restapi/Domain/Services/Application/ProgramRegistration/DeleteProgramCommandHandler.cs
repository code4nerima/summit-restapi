using CfjSummit.Domain.Repositories;
using MediatR;
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
            var p = _repository.GetAll().SingleOrDefault(x => x.ProgramId == request.ProgramId);
            if (p == null) { return 0; }
            _repository.Remove(p);
            return await _repository.SaveChangesAsync();
        }
    }
}
