using CfjSummit.Domain.Models.DTOs.UserProfiles;
using System.Text.Json.Serialization;

namespace CfjSummit.Domain.Models.DTOs.Programs.Attatchments
{
    public class ProgramOwnerDTO
    {
        [JsonPropertyName("uid")]
        public string Uid { get; set; }

        [JsonPropertyName("name")]
        public UserNameDTO UserName { get; set; }
    }
}
