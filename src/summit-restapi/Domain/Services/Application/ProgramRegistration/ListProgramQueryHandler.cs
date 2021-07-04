﻿using CfjSummit.Domain.Models.DTOs;
using CfjSummit.Domain.Models.DTOs.Programs;
using CfjSummit.Domain.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

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
                    GenreGuids = p.ProgramGenres.Select(x => x.Genre.GenreGuid).ToList()
                }).ToList()
            };
        }

    }
}
