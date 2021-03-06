using CfjSummit.Domain.Models.DTOs.Programs.Attatchments;
using System.Collections.Generic;
using System.Text.Json.Serialization;

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

        [JsonPropertyName("inputCompleted")]
        public string InputCompleted { set; get; }

        [JsonPropertyName("udtalkWebURL")]
        public virtual string UdTalkWebURL { get; set; }
        [JsonPropertyName("udtalkAppURL")]
        public virtual string UdTalkAppURL { get; set; }

        [JsonPropertyName("broadcastingURL")]
        public virtual string BroadcastingURL { get; set; }

        [JsonPropertyName("presentationURL")]
        public virtual string PresentationURL { get; set; }

        [JsonPropertyName("grarecoWorkingURL")]
        public virtual string GrarecoWorkingURL { get; set; }

        [JsonPropertyName("genreIds")]
        public List<string> GenreGuids { set; get; } = new();

        [JsonPropertyName("urls")]
        public List<ProgramLinkDTO> ProgramLinks { set; get; } = new();

        //[JsonPropertyName("genres")]
        //public List<GenreDTO> Genres { set; get; } = new();
    }
}
