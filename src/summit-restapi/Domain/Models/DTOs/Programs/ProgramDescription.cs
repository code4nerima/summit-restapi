using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace CfjSummit.Domain.Models.DTOs.Programs
{
    public class ProgramDescription
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
