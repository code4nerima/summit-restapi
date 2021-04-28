using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace CfjSummit.Domain.Models.DTOs.UserProfiles
{
    public class UserName
    {
        [JsonPropertyName("ja")]
        public string Ja { get; set; }

        [JsonPropertyName("en")]
        public string En { get; set; }

        [JsonPropertyName("zh-TW")]
        public string ZhTw { get; set; }

        [JsonPropertyName("zh-CN")]
        public string ZhCn { get; set; }
    }
}
