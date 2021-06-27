using CfjSummit.Domain.Models.DTOs;
using CfjSummit.Domain.Models.DTOs.Programs.Attatchments;
using CfjSummit.Domain.Models.Entities;
using CfjSummit.Domain.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CfjSummit.Domain.Services.Application.ProgramRegistration.Attachments
{
    public class ListGenreQueryHandler : IRequestHandler<ListGenreQuery, ListGenreResponseDTO>
    {
        private readonly IQueryableRepository<Genre> _repository;

        public ListGenreQueryHandler(IQueryableRepository<Genre> repository)
        {
            _repository = repository;
        }

        public async Task<ListGenreResponseDTO> Handle(ListGenreQuery request, CancellationToken cancellationToken)
        {
            var takeCount = request.ListGenreRequestDTO.Limit;
            if (takeCount <= 0) { takeCount = int.MaxValue; }

            var query = await _repository.GetAll()
                                        .OrderBy(x => x.Name_Ja)
                                        .Skip(request.ListGenreRequestDTO.Start)
                                        .Take(takeCount)
                                        .ToListAsync(cancellationToken: cancellationToken);

            return new ListGenreResponseDTO()
            {
                TotalCount = query.Count,
                Grenres = query.Select(x => new GenreDTO()
                {
                    GenreGuid = x.GenreGuid,
                    Name = new MultilingualValue()
                    {
                        Ja = x.Name_Ja,
                        En = x.Name_En,
                        ZhTw = x.Name_Zh_Tw,
                        ZhCn = x.Name_Zh_Cn
                    }
                }).ToList()
            };
        }
    }
}
