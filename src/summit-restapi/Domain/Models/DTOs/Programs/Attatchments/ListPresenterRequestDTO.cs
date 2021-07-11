using System.Text.Json.Serialization;

namespace CfjSummit.Domain.Models.DTOs.Programs.Attatchments
{
    public class ListPresenterRequestDTO : ListRequestDTO
    {
        [JsonPropertyName("programId")]
        public string ProgramGuid { get; set; }
    }
}
