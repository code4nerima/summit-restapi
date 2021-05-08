using CfjSummit.Domain.Models.DTOs;
using CfjSummit.Domain.Models.DTOs.Programs.Attatchments;
using CfjSummit.Domain.Repositories;
using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CfjSummit.Domain.Services.Application.ProgramRegistration
{
    public class GetProgramOwnersQueryHandler : IRequestHandler<GetProgramOwnersQuery, GetProgramOwnersResponseDTO>
    {
        private readonly IProgramRepository _repository;

        public GetProgramOwnersQueryHandler(IProgramRepository repository)
        {
            _repository = repository;
        }

        public async Task<GetProgramOwnersResponseDTO> Handle(GetProgramOwnersQuery request, CancellationToken cancellationToken)
        {
            var p = await _repository.GetProgramWithOwnersAsync(request.ProgramIdDTO.ProgramGuid);
            var items = p.ProgramOwners.Select(x => new ProgramOwnerDTO()
            {
                Uid = x.UserProfile.Uid,
                UserName = new MultilingualValue()
                {
                    Ja = x.UserProfile.Name_Ja,
                    Ja_Kana = x.UserProfile.Name_Ja_Kana,
                    En = x.UserProfile.Name_En,
                    ZhTw = x.UserProfile.Name_Zh_Tw,
                    ZhCn = x.UserProfile.Name_Zh_Cn
                }
            }).ToList();
            return new GetProgramOwnersResponseDTO()
            {
                TotalCount = items.Count,
                Owners = items
            };

        }
    }
}
