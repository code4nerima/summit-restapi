using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace CfjSummit.Domain.Models.DTOs.Tracks
{
    public class ListTrackResponseDTO : ListResponseDTO
    {
        [JsonPropertyName("tracks")]
        public List<TrackDTO> Tracks { get; set; }

    }
}
