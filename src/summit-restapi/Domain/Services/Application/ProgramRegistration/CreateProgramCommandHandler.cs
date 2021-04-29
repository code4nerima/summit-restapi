using CfjSummit.Domain.Models.Entities;
using CfjSummit.Domain.Repositories;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace CfjSummit.Domain.Services.Application.ProgramRegistration
{
    public class CreateProgramCommandHandler : IRequestHandler<CreateProgramCommand, string>
    {
        private readonly IProgramRepository _repository;

        public CreateProgramCommandHandler(IProgramRepository repository)
        {
            _repository = repository;
        }

        public async Task<string> Handle(CreateProgramCommand request, CancellationToken cancellationToken)
        {
            var p = new Program(request.RegisterProgramRequestDTO.Title, request.RegisterProgramRequestDTO.Category);
            _repository.Add(p);
            _ = await _repository.SaveChangesAsync();
            return p.ProgramId;
        }
    }
}
