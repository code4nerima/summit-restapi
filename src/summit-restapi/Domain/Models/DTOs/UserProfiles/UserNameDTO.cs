using System.Text.Json.Serialization;

namespace CfjSummit.Domain.Models.DTOs.UserProfiles
{
    public class UserNameDTO
    {
        [JsonPropertyName("ja")]
        public string Ja { get; set; }

        [JsonPropertyName("ja_kana")]
        public string Ja_Kana { get; set; }

        [JsonPropertyName("en")]
        public string En { get; set; }

        [JsonPropertyName("zh-TW")]
        public string ZhTw { get; set; }

        [JsonPropertyName("zh-CN")]
        public string ZhCn { get; set; }
    }
}
