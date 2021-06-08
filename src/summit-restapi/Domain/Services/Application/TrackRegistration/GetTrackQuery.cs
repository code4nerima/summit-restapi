using CfjSummit.Domain.Models.DTOs.Tracks;
using MediatR;

namespace CfjSummit.Domain.Services.Application.TrackRegistration
{
    public class GetTrackQuery : IRequest<TrackDTO>
    {
        public string TrackGuid { get; }

        public GetTrackQuery(string trackGuid)
        {
            TrackGuid = trackGuid;
        }
    }
}
