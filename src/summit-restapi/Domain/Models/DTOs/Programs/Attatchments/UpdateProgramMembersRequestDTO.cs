using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace CfjSummit.Domain.Models.DTOs.Programs.Attatchments
{
    public class UpdateProgramMembersRequestDTO : ProgramKeyDataDTO
    {
        [JsonPropertyName("members")]
        public List<string> MemberUids { get; set; }
    }
}
