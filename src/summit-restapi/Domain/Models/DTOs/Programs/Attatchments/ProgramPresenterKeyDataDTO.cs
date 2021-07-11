using System.Text.Json.Serialization;

namespace CfjSummit.Domain.Models.DTOs.Programs.Attatchments
{
    public class ProgramPresenterKeyDataDTO : ProgramKeyDataDTO
    {
        [JsonPropertyName("presenterId")]
        public string ProgramPresenterGuid { get; set; }

    }
}
