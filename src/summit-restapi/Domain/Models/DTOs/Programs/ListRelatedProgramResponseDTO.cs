using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace CfjSummit.Domain.Models.DTOs.Programs
{
    public class ListRelatedProgramResponseDTO
    {
        [JsonPropertyName("ownerOfPrograms")]
        public List<ProgramDTO> OwnerOfPrograms { get; set; }

        [JsonPropertyName("memberOfPrograms")]
        public List<ProgramDTO> MemberOfPrograms { get; set; }

        [JsonPropertyName("submittedPrograms")]
        public List<ProgramDTO> SubmittedPrograms { get; set; }
    }
}
