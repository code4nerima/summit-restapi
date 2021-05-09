using CfjSummit.Domain.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace CfjSummit.Domain.Services.Application.TrackRegistration
{
    public class UpdateTrackCommandHandler : IRequestHandler<UpdateTrackCommand, string>
    {
        private readonly ITrackRepository _repository;

        public UpdateTrackCommandHandler(ITrackRepository repository)
        {
            _repository = repository;
        }

        public async Task<string> Handle(UpdateTrackCommand request, CancellationToken cancellationToken)
        {
            var track = await _repository.GetAll().SingleOrDefaultAsync(x => x.TrackGuid == request.TrackDTO.TrackGuid);
            if (track == null) { throw new Exception(); }
            track.Update(request.TrackDTO);
            _repository.Update(track);
            await _repository.SaveChangesAsync();
            return track.TrackGuid;

        }
    }
}
