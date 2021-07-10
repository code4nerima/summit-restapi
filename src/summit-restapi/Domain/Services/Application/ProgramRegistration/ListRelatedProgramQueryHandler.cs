using CfjSummit.Domain.Models.DTOs.Programs;
using CfjSummit.Domain.Models.Entities;
using CfjSummit.Domain.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CfjSummit.Domain.Services.Application.ProgramRegistration
{
    public class ListRelatedProgramQueryHandler : IRequestHandler<ListRelatedProgramQuery, ListRelatedProgramResponseDTO>
    {
        private readonly IQueryableRepository<Program> _repository;

        public ListRelatedProgramQueryHandler(IQueryableRepository<Program> repository)
        {
            _repository = repository;
        }

        public async Task<ListRelatedProgramResponseDTO> Handle(ListRelatedProgramQuery request, CancellationToken cancellationToken)
        {
            var programs = await _repository.GetAll()
                                            .Include(x => x.ProgramUserProfiles)
                                            .ThenInclude(x => x.UserProfile)
                                            .Include(x => x.Track)
                                            .Include(x => x.ProgramGenres)
                                            .ThenInclude(x => x.Genre)
                                            .ToListAsync(cancellationToken);

            return new ListRelatedProgramResponseDTO()
            {
                SubmittedPrograms = programs.Where(x => x.Email == request.ListRelatedProgramRequestDTO.SubmittedEmail)
                                           .Select(x => ProgramDTO.CreateDto(x))
                                           .ToList(),
                OwnerOfPrograms = programs.Where(x => x.ProgramOwnerUserProfiles.Any(x => x.UserProfile.Uid == request.ListRelatedProgramRequestDTO.ProgramOwnerUid))
                                          .Select(x => ProgramDTO.CreateDto(x))
                                          .ToList(),
                MemberOfPrograms = programs.Where(x => x.ProgramMemberUserProfiles.Any(x => x.UserProfile.Uid == request.ListRelatedProgramRequestDTO.ProgramMemberUid))
                                           .Select(x => ProgramDTO.CreateDto(x))
                                           .ToList()
            };
        }

    }
}
