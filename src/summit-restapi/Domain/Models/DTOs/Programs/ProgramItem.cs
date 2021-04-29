using CfjSummit.Domain.Models.DTOs.UserProfiles;
using CfjSummit.Domain.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace CfjSummit.Domain.Models.DTOs.Programs
{
    //HACK 別にItemっていらないんだけれど、Programだけだと名前がProgram.csと被るので回避
    public class ProgramItem
    {
        [JsonPropertyName("title")]
        public ProgramTitle Title { set; get; }

        [JsonPropertyName("category")]
        public ProgramCategory Category { set; get; }

        [JsonPropertyName("description")]
        public ProgramDescription Description { set; get; }

        private List<ProgramOwner> _programOwners = new();
        [JsonPropertyName("owners")]
        public IReadOnlyCollection<ProgramOwner> Owners => _programOwners;

        private List<ProgramMember> _programMembers = new();
        [JsonPropertyName("members")]
        public IReadOnlyCollection<ProgramMember> Members => _programMembers;

        public void AddProgramOwner(ProgramOwner programOwner)
        {
            _programOwners.Add(programOwner);
        }
        public void AddProgramMember(ProgramMember programMember)
        {
            _programMembers.Add(programMember);
        }
    }
}
