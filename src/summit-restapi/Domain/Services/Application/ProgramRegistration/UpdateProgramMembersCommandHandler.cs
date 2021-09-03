using CfjSummit.Domain.Models.Entities;
using CfjSummit.Domain.Repositories;
using MediatR;
using System;
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

            var userDic = _userProfileRepository.GetAll().ToDictionary(x => x.Uid, x => x.Id);

            var tps = request.UpdateProgramMembersRequestDTO.MemberDetailDTOs.Select(x => Tuple.Create(userDic[x.Uid], x.StaffRole)).ToList();
            program.AddRangeProgramMembers(tps);

            _repository.Update(program);
            return await _repository.SaveChangesAsync();

        }
    }
}
