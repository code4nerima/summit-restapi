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
    public class ListProgramGrarecoQuery : IRequest<ListGrarecoResponseDTO>
    {
        public ListProgramGrarecoQuery(ListGrarecoRequestDTO dto)
        {
            ListGrarecoRequestDTO = dto;
        }

        public ListGrarecoRequestDTO ListGrarecoRequestDTO { get; }
    }
    internal class ListProgramGrarecoQueryHandler : IRequestHandler<ListProgramGrarecoQuery, ListGrarecoResponseDTO>
    {
        private readonly IQueryableRepository<Program> _repository;

        public ListProgramGrarecoQueryHandler(IQueryableRepository<Program> repository)
        {
            _repository = repository;
        }

        public async Task<ListGrarecoResponseDTO> Handle(ListProgramGrarecoQuery request, CancellationToken cancellationToken)
        {
            var takeCount = request.ListGrarecoRequestDTO.Limit;
            if (takeCount <= 0) { takeCount = int.MaxValue; }


            var programGrarecos = await _repository.GetAll()
                                                     .Include(x => x.ProgramGrarecos)
                                                     .Where(x => x.ProgramGuid == request.ListGrarecoRequestDTO.ProgramGuid)
                                                     .SelectMany(x => x.ProgramGrarecos)
                                                     .OrderBy(x => x.SortOrder)
                                                     .ThenBy(x => x.Name_Ja_Kana)
                                                     .Skip(request.ListGrarecoRequestDTO.Start)
                                                     .Take(takeCount)
                                                     .ToListAsync(cancellationToken: cancellationToken);
            return new ListGrarecoResponseDTO()
            {
                ProgramGrarecos = programGrarecos.Select(x => ProgramGrarecoDTO.CreateDto(x)).ToList()
            };
        }
    }

}
