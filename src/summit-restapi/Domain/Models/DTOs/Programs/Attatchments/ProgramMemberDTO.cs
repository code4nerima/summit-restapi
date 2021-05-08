using System.Text.Json.Serialization;

namespace CfjSummit.Domain.Models.DTOs.Programs.Attatchments
{
    public class ProgramMemberDTO
    {
        [JsonPropertyName("uid")]
        public string Uid { get; set; }

        [JsonPropertyName("name")]
        public MultilingualValue UserName { get; set; }

    }
}
