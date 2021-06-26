using MediatR;

namespace CfjSummit.Domain.Services.Application.TrackRegistration
{
    public class DeleteTrackCommand : IRequest<bool>
    {
        public string TrackGuid { get; }

        public DeleteTrackCommand(string trackGuid)
        {
            TrackGuid = trackGuid;
        }

    }
}
