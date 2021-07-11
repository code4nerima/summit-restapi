using System.Text.Json.Serialization;

namespace CfjSummit.Domain.Models.DTOs.Programs.Attatchments
{
    public class ProgramOwnerDTO
    {
        [JsonPropertyName("uid")]
        public string Uid { get; set; }

        [JsonPropertyName("name")]
        public MultilingualValue UserName { get; set; }

        [JsonPropertyName("photoURL")]
        public string PhotoURL { get; set; }

    }
}
