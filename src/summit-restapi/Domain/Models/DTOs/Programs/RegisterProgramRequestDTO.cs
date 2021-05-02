using CfjSummit.Domain.Models.Enums;
using System;
using System.Text.Json.Serialization;

namespace CfjSummit.Domain.Models.DTOs.Programs
{
    public class RegisterProgramRequestDTO
    {
        [JsonPropertyName("title")]
        public ProgramTitleDTO Title { set; get; }

        [JsonPropertyName("date")]
        public DateTime Date { set; get; }

        [JsonPropertyName("startTime")]
        public string StartTime { set; get; }

        [JsonPropertyName("endTime")]
        public string EndTime { set; get; }

        [JsonPropertyName("trackId")]
        public string TrackId { set; get; }

        [JsonPropertyName("category")]
        public ProgramCategory Category { set; get; }
    }
}
