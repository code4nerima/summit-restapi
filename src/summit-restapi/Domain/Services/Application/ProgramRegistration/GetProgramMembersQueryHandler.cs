using CfjSummit.Domain.Models.DTOs;
using CfjSummit.Domain.Models.DTOs.Programs.Attatchments;
using CfjSummit.Domain.Repositories;
using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CfjSummit.Domain.Services.Application.ProgramRegistration
{
    public class GetProgramMembersQueryHandler : IRequestHandler<GetProgramMembersQuery, GetProgramMembersResponseDTO>
    {
        private readonly IProgramRepository _repository;

        public GetProgramMembersQueryHandler(IProgramRepository repository)
        {
            _repository = repository;
        }

        public async Task<GetProgramMembersResponseDTO> Handle(GetProgramMembersQuery request, CancellationToken cancellationToken)
        {
            var p = await _repository.GetProgramWithUserProfilesAsync(request.ProgramKeyDataDTO.ProgramGuid);
            var items = p.ProgramMemberUserProfiles.Select(x => new ProgramMemberDTO()
            {
                Uid = x.UserProfile.Uid,
                UserName = new MultilingualValue()
                {
                    Ja = x.UserProfile.Name_Ja,
                    Ja_Kana = x.UserProfile.Name_Ja_Kana,
                    En = x.UserProfile.Name_En,
                    ZhTw = x.UserProfile.Name_Zh_Tw,
                    ZhCn = x.UserProfile.Name_Zh_Cn
                },
                PhotoURL = x.UserProfile.PhotoURL,
                StaffRole = x.StaffRole
            }).ToList();
            return new GetProgramMembersResponseDTO()
            {
                TotalCount = items.Count,
                Members = items
            };
        }
    }
}
