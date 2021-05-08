using System.Text.Json.Serialization;

namespace CfjSummit.Domain.Models.DTOs.Tracks
{
    public class TrackKeyDataDTO
    {
        [JsonPropertyName("trackId")]
        public string TrackGuid { get; set; }

    }
}
