using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace CfjSummit.Domain.Models.DTOs.UserProfiles
{
    public class ListUserProfileResponseDTO : ListResponseDTO
    {
        [JsonPropertyName("userProfiles")]
        public List<UserProfileDTO> UserProfiles { get; set; }

    }
}
