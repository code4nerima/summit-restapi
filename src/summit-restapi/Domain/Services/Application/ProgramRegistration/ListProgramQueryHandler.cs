using CfjSummit.Domain.Models.DTOs;
using CfjSummit.Domain.Models.DTOs.Programs;
using CfjSummit.Domain.Models.DTOs.Programs.Attatchments;
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
                .Include(x => x.ProgramGenres)
                .ThenInclude(x => x.Genre)
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
                Programs = query.Select(p => new ProgramPartsDataDTO()
                {
                    ProgramGuid = p.ProgramGuid,
                    Category = p.ProgramCategory,
                    Title = new MultilingualValue()
                    {
                        Ja = p.Title_Ja,
                        En = p.Title_En,
                        ZhTw = p.Title_Zh_Tw,
                        ZhCn = p.Title_Zh_Cn
                    },
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

                    Description = new MultilingualValue()
                    {
                        Ja = p.Description_Ja,
                        En = p.Description_En,
                        ZhTw = p.Description_Zh_Tw,
                        ZhCn = p.Description_Zh_Cn
                    },
                    Email = p.Email,
                    Genres = p.ProgramGenres.Select(x => new GenreDTO()
                    {
                        GenreGuid = x.Genre.GenreGuid,
                        Name = new MultilingualValue()
                        {
                            Ja = x.Genre.Name_Ja,
                            En = x.Genre.Name_En,
                            ZhTw = x.Genre.Name_Zh_Tw,
                            ZhCn = x.Genre.Name_Zh_Cn
                        }
                    }).ToList(),
                }).ToList()
            };
        }
    }
}
