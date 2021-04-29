using CfjSummit.Domain.Models.Enums;
using System.Text.Json.Serialization;

namespace CfjSummit.Domain.Models.DTOs.Programs
{
    public class EditProgramRequestDTO
    {
        [JsonPropertyName("programId")]
        public string ProgramId { get; set; }

        [JsonPropertyName("title")]
        public ProgramTitleDTO Title { set; get; }

        [JsonPropertyName("category")]
        public ProgramCategory Category { set; get; }

        [JsonPropertyName("description")]
        public ProgramDescriptionDTO Description { set; get; }
    }
}
