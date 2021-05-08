using CfjSummit.Domain.Models.DTOs.Tracks;
using MediatR;

namespace CfjSummit.Domain.Services.Application.TrackRegistration
{
    public class ListTrackQuery : IRequest<ListTrackResponseDTO>
    {
        public ListTrackRequestDTO ListTrackRequestDTO { get; set; }

        public ListTrackQuery(ListTrackRequestDTO dto)
        {
            ListTrackRequestDTO = dto;
        }
    }
}
