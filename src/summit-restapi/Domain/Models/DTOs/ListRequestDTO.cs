using System.Text.Json.Serialization;

namespace CfjSummit.Domain.Models.DTOs
{
    public class ListRequestDTO
    {
        [JsonPropertyName("start")]
        public int Start { get; set; }
        [JsonPropertyName("limit")]
        public int Limit { get; set; }
    }
}
