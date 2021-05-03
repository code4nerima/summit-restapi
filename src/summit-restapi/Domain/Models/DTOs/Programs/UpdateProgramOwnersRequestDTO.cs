using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace CfjSummit.Domain.Models.DTOs.Programs
{
    public class UpdateProgramOwnersRequestDTO
    {
        [JsonPropertyName("programId")]
        public string ProgramId { get; set; }
        [JsonPropertyName("owners")]
        public List<string> OwnerUids { get; set; }
    }
}
