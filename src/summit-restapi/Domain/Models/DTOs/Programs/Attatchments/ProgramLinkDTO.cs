using System.Text.Json.Serialization;

namespace CfjSummit.Domain.Models.DTOs.Programs.Attatchments
{
    public class ProgramLinkDTO
    {
        [JsonPropertyName("sortOrder")]
        public int SortOrder { get; set; }

        [JsonPropertyName("title")]
        public MultilingualValue Title { get; set; }

        [JsonPropertyName("url")]
        public string Url { get; set; }
    }
}
