using CfjSummit.Domain.Models.Entities;
using CfjSummit.Domain.Repositories;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace CfjSummit.Domain.Services.Application.TrackRegistration
{
    public class CreateTrackCommandHandler : IRequestHandler<CreateTrackCommand, string>
    {
        private readonly ITrackRepository _repository;

        public CreateTrackCommandHandler(ITrackRepository repository)
        {
            _repository = repository;
        }

        public async Task<string> Handle(CreateTrackCommand request, CancellationToken cancellationToken)
        {
            var newTrack = new Track(request.TrackDTO);
            _repository.Add(newTrack);
            await _repository.SaveChangesAsync();
            return newTrack.TrackGuid;
        }
    }
}
