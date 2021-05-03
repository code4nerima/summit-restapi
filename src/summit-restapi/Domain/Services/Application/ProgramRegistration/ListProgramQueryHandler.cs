using CfjSummit.Domain.Models.DTOs.Programs;
using CfjSummit.Domain.Models.Enums;
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
                .OrderBy(x => x.Date)
                .ThenBy(x => x.StartTime)
                .Skip(request.ListProgramRequestDTO.Start)
                .Take(takeCount)
                .ToListAsync(cancellationToken: cancellationToken);

            return new ListProgramResponseDTO()
            {
                TotalCount = query.Count,
                Programs = query.Select(x => new ListProgramResponseDataDTO()
                {
                    ProgramId = x.ProgramId,
                    Category = (ProgramCategory)x.ProgramCategory,
                    Title = new ProgramTitleDTO()
                    {
                        Ja = x.Title_Ja,
                        En = x.Title_En,
                        ZhTw = x.Title_Zh_Tw,
                        ZhCn = x.Title_Zh_Cn
                    }
                }).ToList()
            };
        }
    }
}
