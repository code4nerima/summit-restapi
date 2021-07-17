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
    public class GetProgramPresenterQuery : IRequest<ProgramPresenterDTO>
    {
        public GetProgramPresenterQuery(ProgramPresenterKeyDataDTO dto)
        {
            ProgramPresenterKeyDataDTO = dto;
        }

        public ProgramPresenterKeyDataDTO ProgramPresenterKeyDataDTO { get; }
    }
    internal class GetProgramPresenterQueryHandler : IRequestHandler<GetProgramPresenterQuery, ProgramPresenterDTO>
    {
        private readonly IQueryableRepository<Program> _repository;
        public GetProgramPresenterQueryHandler(IQueryableRepository<Program> repository)
        {
            _repository = repository;
        }

        public async Task<ProgramPresenterDTO> Handle(GetProgramPresenterQuery request, CancellationToken cancellationToken)
        {
            return await _repository.GetAll()
                                    .Include(x => x.ProgramPresenters)
                                    .Where(x => x.ProgramGuid == request.ProgramPresenterKeyDataDTO.ProgramGuid)
                                    .SelectMany(x => x.ProgramPresenters)
                                    .Where(x => x.ProgramPresenterGuid == request.ProgramPresenterKeyDataDTO.ProgramPresenterGuid)
                                    .Select(x => ProgramPresenterDTO.CreateDto(x))
                                    .SingleOrDefaultAsync(cancellationToken: cancellationToken);
        }
    }
}
