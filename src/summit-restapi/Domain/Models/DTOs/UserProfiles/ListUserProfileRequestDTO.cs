using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace CfjSummit.Domain.Models.DTOs.UserProfiles
{
    public class ListUserProfileRequestDTO : ListRequestDTO
    {
        [JsonPropertyName("roles")]
        public List<int> Roles { get; set; }
    }
}
