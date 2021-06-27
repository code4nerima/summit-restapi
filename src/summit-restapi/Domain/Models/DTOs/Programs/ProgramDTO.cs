using CfjSummit.Domain.Models.DTOs.Programs.Attatchments;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace CfjSummit.Domain.Models.DTOs.Programs
{
    public class ProgramDTO : ProgramPartsDataDTO
    {
        [JsonPropertyName("owners")]
        public List<ProgramOwnerDTO> ProgramOwners { set; get; } = new();

        [JsonPropertyName("presenters")]
        public List<ProgramPresenterDTO> ProgramPresenters { set; get; } = new();

        [JsonPropertyName("members")]
        public List<ProgramMemberDTO> ProgramMembers { set; get; } = new();


    }
}
