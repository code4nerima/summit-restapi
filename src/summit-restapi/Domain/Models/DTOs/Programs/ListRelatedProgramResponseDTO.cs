using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace CfjSummit.Domain.Models.DTOs.Programs
{
    public class ListRelatedProgramResponseDTO
    {
        [JsonPropertyName("ownerOfPrograms")]
        public List<string> OwnerOfPrograms { get; set; }

        [JsonPropertyName("memberOfPrograms")]
        public List<string> MemberOfPrograms { get; set; }

        [JsonPropertyName("submittedProgram")]
        public List<string> SubmittedProgram { get; set; }
    }
}
