using CfjSummit.Domain.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CfjSummit.Domain.Services.Application.TrackRegistration
{
    public class DeleteTrackCommandHandler : IRequestHandler<DeleteTrackCommand, bool>
    {
        private readonly ITrackRepository _repository;

        public DeleteTrackCommandHandler(ITrackRepository repository)
        {
            _repository = repository;
        }

        public async Task<bool> Handle(DeleteTrackCommand request, CancellationToken cancellationToken)
        {
            var track = await _repository.GetAll()
                .Include(x => x.Programs)
                .SingleOrDefaultAsync(x => x.TrackGuid == request.TrackGuid, cancellationToken: cancellationToken);

            if (track.Programs.Any()) { return false; }
            _repository.Remove(track);
            _ = await _repository.SaveChangesAsync();
            return true;
        }
    }
}
