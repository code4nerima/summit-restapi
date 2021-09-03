using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace CfjSummit.Domain.Models.DTOs.Programs.Attatchments
{
    public class UpdateProgramMembersRequestDTO : ProgramKeyDataDTO
    {
        [JsonPropertyName("members")]
        public List<ProgramMemberDetailDTO> MemberDetailDTOs { get; set; }
    }
    public class ProgramMemberDetailDTO
    {
        [JsonPropertyName("uid")]
        public string Uid { get; set; }

        [JsonPropertyName("staffRole")]
        public int StaffRole { get; set; }

    }
}
