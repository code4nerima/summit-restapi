using System.Text.Json.Serialization;

namespace CfjSummit.Domain.Models.DTOs.UserProfiles
{
    public class UidDTO
    {
        [JsonPropertyName("uid")]
        public string Uid { get; set; }

    }
}
