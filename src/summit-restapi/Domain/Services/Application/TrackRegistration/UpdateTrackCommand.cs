using CfjSummit.Domain.Models.DTOs.Tracks;
using MediatR;

namespace CfjSummit.Domain.Services.Application.TrackRegistration
{
    public class UpdateTrackCommand : IRequest<int>
    {
        public TrackDTO TrackDTO { get; set; }
        public UpdateTrackCommand(TrackDTO dto)
        {
            TrackDTO = dto;
        }
    }
}
