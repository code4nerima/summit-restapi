using CfjSummit.Domain.Models.Enums;
using System.Text.Json.Serialization;

namespace CfjSummit.Domain.Models.DTOs.Programs
{
    public class ProgramPartsDataDTO : ProgramKeyDataDTO
    {
        [JsonPropertyName("title")]
        public TitleDTO Title { set; get; }

        [JsonPropertyName("category")]
        public ProgramCategory Category { set; get; }

        [JsonPropertyName("date")]
        public string Date { set; get; }

        [JsonPropertyName("startTime")]
        public string StartTime { set; get; }

        [JsonPropertyName("endTime")]
        public string EndTime { set; get; }

        [JsonPropertyName("trackId")]
        public string TrackId { set; get; }

        [JsonPropertyName("description")]
        public DescriptionDTO Description { set; get; }

    }
}
