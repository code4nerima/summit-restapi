using System.Text.Json.Serialization;

namespace CfjSummit.Domain.Models.DTOs.Tracks
{
    public class TrackDTO : TrackKeyDataDTO
    {
        [JsonPropertyName("name")]
        public MultilingualValue Name { set; get; }

    }
}
