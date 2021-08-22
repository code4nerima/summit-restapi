using CfjSummit.Domain.Models.DTOs.Programs;
using CfjSummit.Domain.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace CfjSummit.Domain.Services.Application.ProgramRegistration
{
    public class GetProgramQueryHandler : IRequestHandler<GetProgramQuery, ProgramDTO>
    {
        private readonly IProgramRepository _repository;

        public GetProgramQueryHandler(IProgramRepository repository)
        {
            _repository = repository;
        }

        public async Task<ProgramDTO> Handle(GetProgramQuery request, CancellationToken cancellationToken)
        {
            var p = await _repository
                .GetAll()
                .Include(x => x.ProgramUserProfiles)
                .ThenInclude(x => x.UserProfile)
                .Include(x => x.Track)
                .Include(x => x.ProgramGenres)
                .ThenInclude(x => x.Genre)
                .Include(x => x.ProgramPresenters)
                .ThenInclude(x => x.ProgramPresenterLinks)
                .Include(x => x.ProgramLinks)
                .Include(x => x.ProgramGrarecos)
                .SingleOrDefaultAsync(x => x.ProgramGuid == request.ProgramId, cancellationToken: cancellationToken);
            if (p == null) { return new ProgramDTO(); }

            return ProgramDTO.CreateDto(p);
        }
    }
}
