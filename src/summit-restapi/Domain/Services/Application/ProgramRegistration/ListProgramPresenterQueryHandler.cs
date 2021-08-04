using CfjSummit.Domain.Models.DTOs.Programs.Attatchments;
using CfjSummit.Domain.Models.Entities;
using CfjSummit.Domain.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CfjSummit.Domain.Services.Application.ProgramRegistration
{
    public class ListProgramPresenterQueryHandler : IRequestHandler<ListProgramPresenterQuery, ListPresenterResponseDTO>
    {
        private readonly IQueryableRepository<Program> _repository;

        public ListProgramPresenterQueryHandler(IQueryableRepository<Program> repository)
        {
            _repository = repository;
        }

        public async Task<ListPresenterResponseDTO> Handle(ListProgramPresenterQuery request, CancellationToken cancellationToken)
        {
            var takeCount = request.ListPresenterRequestDTO.Limit;
            if (takeCount <= 0) { takeCount = int.MaxValue; }


            var programPresenters = await _repository.GetAll()
                                                     .Include(x => x.ProgramPresenters)
                                                     .ThenInclude(x => x.ProgramPresenterLinks)
                                                     .Where(x => x.ProgramGuid == request.ListPresenterRequestDTO.ProgramGuid)
                                                     .SelectMany(x => x.ProgramPresenters)
                                                     .OrderBy(x => x.SortOrder)
                                                     .ThenBy(x => x.Name_Ja_Kana)
                                                     .Skip(request.ListPresenterRequestDTO.Start)
                                                     .Take(takeCount)
                                                     .ToListAsync(cancellationToken: cancellationToken);
            return new ListPresenterResponseDTO()
            {
                ProgramPresenters = programPresenters.Select(x => ProgramPresenterDTO.CreateDto(x)).ToList()
            };
        }
    }
}
