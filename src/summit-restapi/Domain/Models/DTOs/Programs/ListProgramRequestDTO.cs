using System.Text.Json.Serialization;

namespace CfjSummit.Domain.Models.DTOs.Programs
{
    public class ListProgramRequestDTO
    {
        [JsonPropertyName("start")]
        public int Start { get; set; }
        [JsonPropertyName("limit")]
        public int Limit { get; set; }

    }
}
