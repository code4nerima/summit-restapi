using System.Text.Json.Serialization;

namespace CfjSummit.Domain.Models.DTOs.Programs.Attatchments
{
    public class ProgramGrarecoKeyDataDTO : ProgramKeyDataDTO
    {
        [JsonPropertyName("grarecoId")]
        public string ProgramGrarecoGuid { get; set; }

    }
}
