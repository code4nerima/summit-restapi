using CfjSummit.Domain.Models.Enums;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace CfjSummit.Domain.Models.DTOs.UserProfiles
{ 
    public class UserProfile
    {

        [JsonPropertyName("name")]
        public UserName UserName { get; set; }

        [JsonPropertyName("email")]
        public string Email { get; set; }

        [JsonPropertyName("role")]
        public UserRole UserRole { get; set; }

    }
}
