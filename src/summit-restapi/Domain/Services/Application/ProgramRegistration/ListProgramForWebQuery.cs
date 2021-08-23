using CfjSummit.Domain.Models.DTOs.Programs;
using CfjSummit.Domain.Repositories;
using CfjSummit.Domain.Services.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CfjSummit.Domain.Services.Application.ProgramRegistration
{
    public class ListProgramForWebQuery : IRequest<List<ListProgramForWebResponseDTO>>
    {
        public string Lang { get; set; }
        public string Date { get; set; }

        public ListProgramForWebQuery(string lang, string date)
        {
            Lang = lang;
            Date = date;
        }
    }
    internal class ListProgramForWebQueryHandler : IRequestHandler<ListProgramForWebQuery, List<ListProgramForWebResponseDTO>>
    {
        private readonly IProgramRepository _repository;

        public ListProgramForWebQueryHandler(IProgramRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<ListProgramForWebResponseDTO>> Handle(ListProgramForWebQuery request, CancellationToken cancellationToken)
        {
            var whereDate = request.Date switch
            {
                "1" => "2021-09-18",
                "2" => "2021-09-19",
                "" => "2021-09-18",
                null => "2021-09-18",
                _ => "2099-12-31",
            };
            await Task.Run(() => Console.WriteLine("hoge"), cancellationToken);
            return _repository.GetAll()
                .Include(x => x.ProgramPresenters)
                .Include(x => x.Track)
                .Where(x => x.Date == whereDate)
                .ToLookup(x => x.Track.Name_Ja)
                .OrderBy(x => x.Key)
                .Select(x => new ListProgramForWebResponseDTO()
                {
                    TrackName = x.Key,
                    ProgramSimpleDatas = x.OrderBy(pg => pg.StartTime).Select(pg => new ProgramSimpleDataDTO()
                    {
                        ProgramGuid = pg.ProgramGuid,
                        Category = pg.ProgramCategory,
                        StartTime = pg.StartTime,
                        EndTime = pg.EndTime,
                        InputCompleted = pg.InputCompleted,
                        Title = MultilingualConverter.GetValueByLang(request.Lang, pg.Title_Ja, pg.Title_En, pg.Title_Zh_Tw, pg.Title_Zh_Cn),
                        Description = MultilingualConverter.GetValueByLang(request.Lang, pg.Description_Ja, pg.Description_En, pg.Description_Zh_Tw, pg.Description_Zh_Cn),
                        ProgramPresenterNames = pg.ProgramPresenters.OrderBy(pg => pg.SortOrder)
                                                                    .Select(pp => MultilingualConverter.GetValueByLang(request.Lang, pp.Name_Ja, pp.Name_En, pp.Name_Zh_Tw, pp.Name_Zh_Cn))
                                                                    .ToList()
                    }).ToList()
                }).ToList();
        }
    }
}
