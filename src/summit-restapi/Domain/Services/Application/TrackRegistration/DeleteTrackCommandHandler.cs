using CfjSummit.Domain.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CfjSummit.Domain.Services.Application.TrackRegistration
{
    public class DeleteTrackCommandHandler : IRequestHandler<DeleteTrackCommand, int>
    {
        private readonly ITrackRepository _repository;

        public DeleteTrackCommandHandler(ITrackRepository repository)
        {
            _repository = repository;
        }

        public async Task<int> Handle(DeleteTrackCommand request, CancellationToken cancellationToken)
        {
            var track = await _repository.GetAll()
                .Include(x => x.Programs)
                .SingleOrDefaultAsync(x => x.TrackGuid == request.TrackGuid, cancellationToken: cancellationToken);

            if (track.Programs.Any()) { return -1; }
            _repository.Remove(track);
            return await _repository.SaveChangesAsync();
        }
    }
}
