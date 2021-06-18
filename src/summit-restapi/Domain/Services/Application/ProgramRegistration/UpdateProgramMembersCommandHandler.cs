using CfjSummit.Domain.Models.Entities;
using CfjSummit.Domain.Repositories;
using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CfjSummit.Domain.Services.Application.ProgramRegistration
{
    public class UpdateProgramMembersCommandHandler : IRequestHandler<UpdateProgramMembersCommand, int>
    {
        private readonly IProgramRepository _repository;
        private readonly IQueryableRepository<UserProfile> _userProfileRepository;

        public UpdateProgramMembersCommandHandler(IProgramRepository repository, IQueryableRepository<UserProfile> userProfileRepository)
        {
            _repository = repository;
            _userProfileRepository = userProfileRepository;
        }




        public async Task<int> Handle(UpdateProgramMembersCommand request, CancellationToken cancellationToken)
        {
            var program = await _repository.GetProgramWithUserProfilesAsync(request.UpdateProgramMembersRequestDTO.ProgramGuid);

            program.ClearProgramMember();
            var userProfileIds = _userProfileRepository.GetAll()
                .Where(x => request.UpdateProgramMembersRequestDTO.MemberUids.Contains(x.Uid))
                .Select(x => x.Id)
                .ToList();
            program.AddRangeProgramMembers(userProfileIds);
            _repository.Update(program);
            return await _repository.SaveChangesAsync();

        }
    }
}
