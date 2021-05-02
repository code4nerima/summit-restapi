using CfjSummit.Domain.Models.Enums;
using System.Text.Json.Serialization;

namespace CfjSummit.Domain.Models.DTOs.UserProfiles
{
    public class ListUserProfileRequestDTO
    {
        [JsonPropertyName("start")]
        public int Start { get; set; }
        [JsonPropertyName("limit")]
        public int Limit { get; set; }
        [JsonPropertyName("role")]
        public UserRole UserRole { get; set; }

    }
}
