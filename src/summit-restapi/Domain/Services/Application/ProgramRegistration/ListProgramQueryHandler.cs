using CfjSummit.Domain.Models.DTOs;
using CfjSummit.Domain.Models.DTOs.Programs;
using CfjSummit.Domain.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using static CfjSummit.Domain.Models.Entities.Program;

namespace CfjSummit.Domain.Services.Application.ProgramRegistration
{
    public class ListProgramQueryHandler : IRequestHandler<ListProgramQuery, ListProgramResponseDTO>
    {
        private readonly IProgramRepository _repository;

        public ListProgramQueryHandler(IProgramRepository repository)
        {
            _repository = repository;
        }

        public async Task<ListProgramResponseDTO> Handle(ListProgramQuery request, CancellationToken cancellationToken)
        {
            var takeCount = request.ListProgramRequestDTO.Limit;
            if (takeCount <= 0) { takeCount = int.MaxValue; }
            var query = await _repository.GetAll()
                .Include(x => x.Track)
                .Where(x =>

                //どっちも入ってない
                (
                    string.IsNullOrEmpty(request.ListProgramRequestDTO.ProgramOwnerUid) && string.IsNullOrEmpty(request.ListProgramRequestDTO.ProgramMemberUid)
                )

                ||

                //どっちも入ってる
                (
                    !string.IsNullOrEmpty(request.ListProgramRequestDTO.ProgramOwnerUid) && !string.IsNullOrEmpty(request.ListProgramRequestDTO.ProgramMemberUid) &&
                    (
                        x.ProgramUserProfiles.Any(x => x.UserProfile.Uid == request.ListProgramRequestDTO.ProgramOwnerUid || x.UserProfile.Uid == request.ListProgramRequestDTO.ProgramMemberUid)
                    )
                )

                ||

                //Ownerのみ
                (
                    !string.IsNullOrEmpty(request.ListProgramRequestDTO.ProgramOwnerUid) &&
                    x.ProgramUserProfiles.Any(x => x.UserProfile.Uid == request.ListProgramRequestDTO.ProgramOwnerUid && x.ProgramRole == (int)ProgramRoleEnum.Owner)
                )

                ||

                //Memberのみ
                (
                    !string.IsNullOrEmpty(request.ListProgramRequestDTO.ProgramMemberUid) &&
                    x.ProgramUserProfiles.Any(x => x.UserProfile.Uid == request.ListProgramRequestDTO.ProgramMemberUid && x.ProgramRole == (int)ProgramRoleEnum.Member)
                )
                )
                .OrderBy(x => x.Date)
                .ThenBy(x => x.StartTime)
                .Skip(request.ListProgramRequestDTO.Start)
                .Take(takeCount)
                .ToListAsync(cancellationToken: cancellationToken);

            return new ListProgramResponseDTO()
            {
                TotalCount = query.Count,
                Programs = query.Select(x => new ProgramPartsDataDTO()
                {
                    ProgramGuid = x.ProgramGuid,
                    Category = x.ProgramCategory,
                    Title = new MultilingualValue()
                    {
                        Ja = x.Title_Ja,
                        En = x.Title_En,
                        ZhTw = x.Title_Zh_Tw,
                        ZhCn = x.Title_Zh_Cn
                    },
                    Date = x.Date,
                    StartTime = x.StartTime,
                    EndTime = x.EndTime,
                    TrackGuid = x.Track?.TrackGuid ?? "",
                    TrackName = new MultilingualValue()
                    {
                        Ja = x.Track?.Name_Ja ?? "",
                        En = x.Track?.Name_En ?? "",
                        ZhTw = x.Track?.Name_Zh_Tw ?? "",
                        ZhCn = x.Track?.Name_Zh_Cn ?? ""
                    },

                    Description = new MultilingualValue()
                    {
                        Ja = x.Description_Ja,
                        En = x.Description_En,
                        ZhTw = x.Description_Zh_Tw,
                        ZhCn = x.Description_Zh_Cn
                    },
                    Email = x.Email
                }).ToList()
            };
        }
    }
}
