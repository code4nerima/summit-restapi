using CfjSummit.Domain.Models.Entities;
using CfjSummit.Domain.Repositories;
using MediatR;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CfjSummit.Domain.Services.Application.ProgramRegistration
{
    public class UpdateProgramCommandHandler : IRequestHandler<UpdateProgramCommand, string>
    {
        private readonly IProgramRepository _repository;
        private readonly IQueryableRepository<Track> _trackRepository;

        public UpdateProgramCommandHandler(IProgramRepository repository, IQueryableRepository<Track> trackRepository)
        {
            _repository = repository;
            _trackRepository = trackRepository;
        }

        public async Task<string> Handle(UpdateProgramCommand request, CancellationToken cancellationToken)
        {
            var p = _repository.GetAll().SingleOrDefault(x => x.ProgramGuid == request.ProgramPartsDataDTO.ProgramGuid);
            if (p == null) { throw new Exception(); }
            p.Update(request.ProgramPartsDataDTO);

            var track = _trackRepository.GetAll().SingleOrDefault(x => x.TrackGuid == request.ProgramPartsDataDTO.TrackGuid);
            if (track != null)
            {
                p.SetTrackId(track.Id);
            }

            _repository.Update(p);
            _ = await _repository.SaveChangesAsync();
            return p.ProgramGuid;
        }
    }
}
