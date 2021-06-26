using System.Text.Json.Serialization;

namespace CfjSummit.Domain.Models.DTOs
{
    public class ListResponseDTO
    {
        [JsonPropertyName("totalCount")]
        public int TotalCount { get; set; }

    }
}
