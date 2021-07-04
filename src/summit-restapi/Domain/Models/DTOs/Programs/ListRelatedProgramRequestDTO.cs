using System.Text.Json.Serialization;

namespace CfjSummit.Domain.Models.DTOs.Programs
{
    public class ListRelatedProgramRequestDTO
    {
        [JsonPropertyName("programOwnerUid")]
        public string ProgramOwnerUid { get; set; }

        [JsonPropertyName("programMemberUid")]
        public string ProgramMemberUid { get; set; }

        [JsonPropertyName("submittedEmail")]
        public string SubmittedEmail { get; set; }
    }
}
