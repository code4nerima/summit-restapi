using CfjSummit.Domain.Models.Enums;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace CfjSummit.Domain.Models.DTOs.Programs
{
    public class ProgramDTO
    {
        [JsonPropertyName("title")]
        public ProgramTitleDTO Title { set; get; }

        [JsonPropertyName("category")]
        public ProgramCategory Category { set; get; }

        [JsonPropertyName("description")]
        public ProgramDescriptionDTO Description { set; get; }

        private List<ProgramOwnerDTO> _programOwners = new();
        [JsonPropertyName("owners")]
        public IReadOnlyCollection<ProgramOwnerDTO> Owners => _programOwners;

        private List<ProgramMemberDTO> _programMembers = new();
        [JsonPropertyName("members")]
        public IReadOnlyCollection<ProgramMemberDTO> Members => _programMembers;

        public void AddProgramOwner(ProgramOwnerDTO programOwner)
        {
            _programOwners.Add(programOwner);
        }
        public void AddProgramMember(ProgramMemberDTO programMember)
        {
            _programMembers.Add(programMember);
        }
    }
}
