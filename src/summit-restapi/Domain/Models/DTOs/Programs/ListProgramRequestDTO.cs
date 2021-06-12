using System.Text.Json.Serialization;

namespace CfjSummit.Domain.Models.DTOs.Programs
{
    public class ListProgramRequestDTO : ListRequestDTO
    {
        [JsonPropertyName("programOwnerUid")]
        public string ProgramOwnerUid { get; set; }

        [JsonPropertyName("programMemberUid")]
        public string ProgramMemberUid { get; set; }
    }
}
