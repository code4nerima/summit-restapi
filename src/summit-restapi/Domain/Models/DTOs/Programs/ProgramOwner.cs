using CfjSummit.Domain.Models.DTOs.UserProfiles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace CfjSummit.Domain.Models.DTOs.Programs
{
    public class ProgramOwner
    {
        [JsonPropertyName("uid")]
        public string Uid { get; set; }

        [JsonPropertyName("name")]
        public UserName UserName { get; set; }
    }
}
