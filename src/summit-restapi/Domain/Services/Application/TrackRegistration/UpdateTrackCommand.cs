using CfjSummit.Domain.Models.DTOs.Tracks;
using MediatR;

namespace CfjSummit.Domain.Services.Application.TrackRegistration
{
    public class UpdateTrackCommand : IRequest<string>
    {
        public TrackDTO TrackDTO { get; set; }
        public UpdateTrackCommand(TrackDTO dto)
        {
            TrackDTO = dto;
        }
    }
}
