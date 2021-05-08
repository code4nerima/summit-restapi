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
            var p = _repository.GetAll().SingleOrDefault(x => x.ProgramGuid == request.ProgramPartsDataDTO.ProgramGuid);
            if (p == null) { throw new Exception(); }
            p.Update(request.ProgramPartsDataDTO);
            _repository.Update(p);
            _ = await _repository.SaveChangesAsync();
            return p.ProgramGuid;
        }
    }
}
