using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace CfjSummit.Domain.Models.DTOs.Programs.Attatchments
{
    public class UpdateProgramOwnersRequestDTO : ProgramKeyDataDTO
    {
        [JsonPropertyName("owners")]
        public List<string> OwnerUids { get; set; }
    }
}
