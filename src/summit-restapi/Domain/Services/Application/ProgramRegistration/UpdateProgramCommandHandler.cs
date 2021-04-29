using CfjSummit.Domain.Repositories;
using MediatR;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CfjSummit.Domain.Services.Application.ProgramRegistration
{
    public class UpdateProgramCommandHandler : IRequestHandler<UpdateProgramCommand, string>
    {
        private readonly IProgramRepository _repository;

        public UpdateProgramCommandHandler(IProgramRepository repository)
        {
            _repository = repository;
        }

        public async Task<string> Handle(UpdateProgramCommand request, CancellationToken cancellationToken)
        {
            var p = _repository.GetAll().SingleOrDefault(x => x.ProgramId == request.EditProgramRequestDTO.ProgramId);
            if (p == null) { throw new Exception(); }
            p.Update(request.EditProgramRequestDTO.Title, request.EditProgramRequestDTO.Category, request.EditProgramRequestDTO.Description);
            _repository.Update(p);
            _ = await _repository.SaveChangesAsync();
            return p.ProgramId;
        }
    }
}
