using System.Text.Json.Serialization;

namespace CfjSummit.Domain.Models.DTOs.UserProfiles
{
    public class GetUserProfileDTO
    {
        [JsonPropertyName("uid")]
        public string Uid { get; set; }

        [JsonPropertyName("name")]
        public UserNameDTO UserName { get; set; }

        [JsonPropertyName("role")]
        public int Role { get; set; }
    }
}
