using System.Text.Json.Serialization;

namespace CfjSummit.Domain.Models.DTOs.Programs
{
    public class ProgramDescriptionDTO
    {
        [JsonPropertyName("ja")]
        public string Ja { get; set; }

        [JsonPropertyName("en")]
        public string En { get; set; }

        [JsonPropertyName("zh-TW")]
        public string ZhTw { get; set; }

        [JsonPropertyName("zh-CN")]
        public string ZhCn { get; set; }

    }
}
