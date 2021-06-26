﻿using System.Text.Json.Serialization;

namespace CfjSummit.Domain.Models.DTOs.Programs
{
    public class ProgramPartsDataDTO : ProgramKeyDataDTO
    {
        [JsonPropertyName("title")]
        public MultilingualValue Title { set; get; }

        [JsonPropertyName("category")]
        public int Category { set; get; }

        [JsonPropertyName("date")]
        public string Date { set; get; }

        [JsonPropertyName("startTime")]
        public string StartTime { set; get; }

        [JsonPropertyName("endTime")]
        public string EndTime { set; get; }

        [JsonPropertyName("trackId")]
        public string TrackGuid { set; get; }

        [JsonPropertyName("trackName")]
        public MultilingualValue TrackName { set; get; }

        [JsonPropertyName("description")]
        public MultilingualValue Description { set; get; }

        [JsonPropertyName("email")]
        public string Email { set; get; }

    }
}
