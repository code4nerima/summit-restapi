using System.Text.Json.Serialization;

namespace CfjSummit.Domain.Models.DTOs.Programs
{
    public class ListProgramForWebRequestDTO
    {
        [JsonPropertyName("lang")]
        public string Language { set; get; }

        [JsonPropertyName("date")]
        public string DateKubun { set; get; }

    }
}
