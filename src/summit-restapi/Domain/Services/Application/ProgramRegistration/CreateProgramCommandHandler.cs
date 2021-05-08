using CfjSummit.Domain.Models.Entities;
using CfjSummit.Domain.Repositories;
using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CfjSummit.Domain.Services.Application.ProgramRegistration
{
    public class CreateProgramCommandHandler : IRequestHandler<CreateProgramCommand, string>
    {
        private readonly IProgramRepository _repository;
        private readonly IQueryableRepository<Track> _trackRepository;

        public CreateProgramCommandHandler(IProgramRepository repository,
            IQueryableRepository<Track> trackRepository)
        {
            _repository = repository;
            _trackRepository = trackRepository;
        }

        public async Task<string> Handle(CreateProgramCommand request, CancellationToken cancellationToken)
        {
            var p = new Program(request.ProgramPartsDataDTO);

            var track = _trackRepository.GetAll().SingleOrDefault(x => x.TrackGuid == request.ProgramPartsDataDTO.TrackGuid);
            if (track != null)
            {
                p.SetTrackId(track.Id);
            }

            _repository.Add(p);
            _ = await _repository.SaveChangesAsync();
            return p.ProgramGuid;
        }
    }
}
