using CfjSummit.Domain.Models.Enums;
using System.Text.Json.Serialization;

namespace CfjSummit.Domain.Models.DTOs.UserProfiles
{
    public class UserProfileDTO
    {
        [JsonPropertyName("uid")]
        public string Uid { get; set; }

        [JsonPropertyName("name")]
        public UserNameDTO UserName { get; set; }

        [JsonPropertyName("role")]
        public UserRole UserRole { get; set; }
    }
}
