using CfjSummit.Domain.Repositories;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace CfjSummit.Domain.Services.Application.ProgramRegistration
{
    public class UpdateProgramOwnersCommandHandler : IRequestHandler<UpdateProgramOwnersCommand, int>
    {
        private readonly IProgramRepository _repository;

        public UpdateProgramOwnersCommandHandler(IProgramRepository repository)
        {
            _repository = repository;
        }
        public async Task<int> Handle(UpdateProgramOwnersCommand request, CancellationToken cancellationToken)
        {
            var program = await _repository.GetProgramWithOwnersAsync(request.UpdateProgramOwnersRequestDTO.ProgramId);
            program.UpdateProgramOwner(request.UpdateProgramOwnersRequestDTO.OwnerUids);
            _repository.Update(program);
            return await _repository.SaveChangesAsync();
        }
    }
}
