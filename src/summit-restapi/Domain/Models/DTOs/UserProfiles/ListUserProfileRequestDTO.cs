using CfjSummit.Domain.Models.Enums;
using System.Text.Json.Serialization;

namespace CfjSummit.Domain.Models.DTOs.UserProfiles
{
    public class ListUserProfileRequestDTO : ListRequestDTO
    {
        [JsonPropertyName("role")]
        public UserRole UserRole { get; set; }

    }
}
