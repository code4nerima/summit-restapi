using CfjSummit.Domain.Models.Enums;
using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace CfjSummit.Domain.Models.DTOs.Programs
{
    public class ProgramDTO
    {
        [JsonPropertyName("title")]
        public ProgramTitleDTO Title { set; get; }

        [JsonPropertyName("category")]
        public ProgramCategory Category { set; get; }

        [JsonPropertyName("date")]
        public DateTime Date { set; get; }

        [JsonPropertyName("startTime")]
        public string StartTime { set; get; }

        [JsonPropertyName("endTime")]
        public string EndTime { set; get; }

        [JsonPropertyName("trackId")]
        public string TrackId { set; get; }

        [JsonPropertyName("description")]
        public ProgramDescriptionDTO Description { set; get; }

        [JsonPropertyName("owners")]
        public List<ProgramOwnerDTO> ProgramOwners { set; get; } = new();

        [JsonPropertyName("presenters")]
        public List<ProgramPresenterDTO> ProgramPresenters { set; get; } = new();

        [JsonPropertyName("members")]
        public List<ProgramMemberDTO> ProgramMembers { set; get; } = new();
    }
}
