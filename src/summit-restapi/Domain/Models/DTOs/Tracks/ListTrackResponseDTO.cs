using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace CfjSummit.Domain.Models.DTOs.Tracks
{
    public class ListTrackResponseDTO
    {
        [JsonPropertyName("totalCount")]
        public int TotalCount { get; set; }
        [JsonPropertyName("tracks")]
        public List<TrackDTO> Tracks { get; set; }

    }
}
