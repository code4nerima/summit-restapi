using CfjSummit.Domain.Models.Enums;
using System.Text.Json.Serialization;

namespace CfjSummit.Domain.Models.DTOs.UserProfiles
{
    public class UserProfile
    {
        [JsonPropertyName("name")]
        public UserName UserName { get; set; }

        //[JsonPropertyName("email")]
        //public string Email { get; set; }

        [JsonPropertyName("role")]
        public UserRole UserRole { get; set; }
    }
}