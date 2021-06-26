using System.Text.Json.Serialization;

namespace CfjSummit.Domain.Models.DTOs.UserProfiles
{
    public class UserProfileDTO
    {
        [JsonPropertyName("uid")]
        public string Uid { get; set; }

        [JsonPropertyName("name")]
        public MultilingualValue UserName { get; set; }

        [JsonPropertyName("role")]
        public int Role { get; set; }

        [JsonPropertyName("photoURL")]
        public string PhotoURL { get; set; }
    }
}
