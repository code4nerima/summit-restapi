using System.Text.Json.Serialization;

namespace CfjSummit.Domain.Models.DTOs.Programs
{
    public class ProgramKeyDataDTO
    {
        [JsonPropertyName("programId")]
        public string ProgramGuid { get; set; }
    }
}
