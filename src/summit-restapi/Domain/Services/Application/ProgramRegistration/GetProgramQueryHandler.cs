using CfjSummit.Domain.Models.DTOs;
using CfjSummit.Domain.Models.DTOs.Programs;
using CfjSummit.Domain.Models.DTOs.Programs.Attatchments;
using CfjSummit.Domain.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CfjSummit.Domain.Services.Application.ProgramRegistration
{
    public class GetProgramQueryHandler : IRequestHandler<GetProgramQuery, ProgramDTO>
    {
        private readonly IProgramRepository _repository;

        public GetProgramQueryHandler(IProgramRepository repository)
        {
            _repository = repository;
        }

        public async Task<ProgramDTO> Handle(GetProgramQuery request, CancellationToken cancellationToken)
        {
            var p = await _repository
                .GetAll()
                .Include(x => x.ProgramUserProfiles)
                .ThenInclude(x => x.UserProfile)
                .Include(x => x.Track)
                .SingleOrDefaultAsync(x => x.ProgramGuid == request.ProgramId, cancellationToken: cancellationToken);
            if (p == null) { return new ProgramDTO(); }

            var dto = new ProgramDTO()
            {
                ProgramGuid = p.ProgramGuid,
                Title = new MultilingualValue()
                {
                    Ja = p.Title_Ja,
                    En = p.Title_En,
                    ZhTw = p.Title_Zh_Tw,
                    ZhCn = p.Title_Zh_Cn
                },
                Category = p.ProgramCategory,
                Date = p.Date,
                StartTime = p.StartTime,
                EndTime = p.EndTime,
                TrackGuid = p.Track?.TrackGuid ?? "",
                TrackName = new MultilingualValue()
                {
                    Ja = p.Track?.Name_Ja ?? "",
                    En = p.Track?.Name_En ?? "",
                    ZhTw = p.Track?.Name_Zh_Tw ?? "",
                    ZhCn = p.Track?.Name_Zh_Cn ?? ""
                },
                ProgramOwners = p.ProgramOwnerUserProfiles.Select(x => new ProgramOwnerDTO()
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
                }).ToList(),
                ProgramMembers = p.ProgramMemberUserProfiles.Select(x => new ProgramMemberDTO()
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
                }).ToList(),
                Description = new MultilingualValue()
                {
                    Ja = p.Description_Ja,
                    En = p.Description_En,
                    ZhTw = p.Description_Zh_Tw,
                    ZhCn = p.Description_Zh_Cn
                },
                Email = p.Email
            };
            return dto;
        }
    }
}
