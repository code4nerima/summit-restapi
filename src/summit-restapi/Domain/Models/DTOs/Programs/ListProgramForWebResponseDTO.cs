using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace CfjSummit.Domain.Models.DTOs.Programs
{
    public class ListProgramForWebResponseDTO
    {
        [JsonPropertyName("trackName")]
        public string TrackName { get; set; }

        [JsonPropertyName("programs")]
        public List<ProgramSimpleDataDTO> ProgramSimpleDatas { get; set; }

    }
    public class ProgramSimpleDataDTO : ProgramKeyDataDTO
    {
        [JsonPropertyName("title")]
        public string Title { set; get; }

        [JsonPropertyName("startTime")]
        public string StartTime { set; get; }

        [JsonPropertyName("endTime")]
        public string EndTime { set; get; }


        [JsonPropertyName("category")]
        public int Category { set; get; }

        //[JsonPropertyName("date")]
        //public string Date { set; get; }


        //[JsonPropertyName("trackId")]
        //public string TrackGuid { set; get; }

        //[JsonPropertyName("trackName")]
        //public MultilingualValue TrackName { set; get; }

        [JsonPropertyName("description")]
        public string Description { set; get; }

        //[JsonPropertyName("email")]
        //public string Email { set; get; }

        [JsonPropertyName("inputCompleted")]
        public string InputCompleted { set; get; }

        //[JsonPropertyName("genreIds")]
        //public List<string> GenreGuids { set; get; } = new();

        //[JsonPropertyName("urls")]
        //public List<ProgramLinkDTO> ProgramLinks { set; get; } = new();

        [JsonPropertyName("presenters")]
        public List<string> ProgramPresenterNames { set; get; } = new();

    }
}
