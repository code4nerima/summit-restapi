using CfjSummit.Domain.Models.DTOs.Tracks;
using MediatR;

namespace CfjSummit.Domain.Services.Application.TrackRegistration
{
    public class CreateTrackCommand : IRequest<string>
    {
        public TrackDTO TrackDTO { get; set; }
        public CreateTrackCommand(TrackDTO dto)
        {
            TrackDTO = dto;
        }
    }
}
