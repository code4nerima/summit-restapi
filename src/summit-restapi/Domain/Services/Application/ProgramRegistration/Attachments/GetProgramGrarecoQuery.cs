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
    public class GetProgramGrarecoQuery : IRequest<ProgramGrarecoDTO>
    {
        public GetProgramGrarecoQuery(ProgramGrarecoKeyDataDTO dto)
        {
            ProgramGrarecoKeyDataDTO = dto;
        }

        public ProgramGrarecoKeyDataDTO ProgramGrarecoKeyDataDTO { get; }
    }
    internal class GetProgramGrarecoQueryHandler : IRequestHandler<GetProgramGrarecoQuery, ProgramGrarecoDTO>
    {
        private readonly IQueryableRepository<Program> _repository;
        public GetProgramGrarecoQueryHandler(IQueryableRepository<Program> repository)
        {
            _repository = repository;
        }

        public async Task<ProgramGrarecoDTO> Handle(GetProgramGrarecoQuery request, CancellationToken cancellationToken)
        {
            return await _repository.GetAll()
                                    .Include(x => x.ProgramGrarecos)
                                    .Where(x => x.ProgramGuid == request.ProgramGrarecoKeyDataDTO.ProgramGuid)
                                    .SelectMany(x => x.ProgramGrarecos)
                                    .Where(x => x.ProgramGrarecoGuid == request.ProgramGrarecoKeyDataDTO.ProgramGrarecoGuid)
                                    .Select(x => ProgramGrarecoDTO.CreateDto(x))
                                    .SingleOrDefaultAsync(cancellationToken: cancellationToken);
        }
    }

}
