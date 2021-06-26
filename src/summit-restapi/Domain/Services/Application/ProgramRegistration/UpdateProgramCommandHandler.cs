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
        private readonly IQueryableRepository<Genre> _genreRepository;

        public UpdateProgramCommandHandler(IProgramRepository repository, IQueryableRepository<Track> trackRepository, IQueryableRepository<Genre> genreRepository)
        {
            _repository = repository;
            _trackRepository = trackRepository;
            _genreRepository = genreRepository;
        }

        public async Task<string> Handle(UpdateProgramCommand request, CancellationToken cancellationToken)
        {
            var p = await _repository.GetProgramWithGenresAsync(request.ProgramPartsDataDTO.ProgramGuid);
            if (p == null) { throw new Exception(); }
            p.Update(request.ProgramPartsDataDTO);

            var track = _trackRepository.GetAll().SingleOrDefault(x => x.TrackGuid == request.ProgramPartsDataDTO.TrackGuid);
            if (track != null)
            {
                p.SetTrackId(track.Id);
            }

            p.ClearProgramGenres();
            if (request.ProgramPartsDataDTO.GenreGuids.Any())
            {
                var genreIds = _genreRepository.GetAll().Where(x => request.ProgramPartsDataDTO.GenreGuids.Contains(x.GenreGuid)).Select(x => x.Id).ToArray();
                p.AddRangeProgramGenres(genreIds);
            }
            _repository.Update(p);
            _ = await _repository.SaveChangesAsync();
            return p.ProgramGuid;
        }
    }
}
