using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace CfjSummit.Domain.Models.DTOs.UserProfiles
{
    public class ListUserProfileResponseDTO
    {
        [JsonPropertyName("totalCount")]
        public int TotalCount { get; set; }
        [JsonPropertyName("userProfiles")]
        public List<GetUserProfileDTO> UserProfiles { get; set; }

    }
}
