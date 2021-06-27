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
    public class GetGenreQueryHandler : IRequestHandler<GetGenreQuery, GenreDTO>
    {
        private readonly IQueryableRepository<Genre> _repository;

        public GetGenreQueryHandler(IQueryableRepository<Genre> repository)
        {
            _repository = repository;
        }

        public async Task<GenreDTO> Handle(GetGenreQuery request, CancellationToken cancellationToken)
        {
            var genreDto = await _repository.GetAll()
                                      .Select(x => new GenreDTO()
                                      {
                                          GenreGuid = x.GenreGuid,
                                          Name = new MultilingualValue()
                                          {
                                              Ja = x.Name_Ja,
                                              En = x.Name_En,
                                              ZhTw = x.Name_Zh_Tw,
                                              ZhCn = x.Name_Zh_Cn
                                          }
                                      }
                                      ).SingleOrDefaultAsync(x => x.GenreGuid == request.GenreGuid, cancellationToken: cancellationToken);
            return genreDto;

        }
    }
}
