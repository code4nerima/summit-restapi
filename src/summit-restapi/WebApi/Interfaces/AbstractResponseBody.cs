using System;
using System.Text.Json.Serialization;

namespace CfjSummit.WebApi.Interfaces
{
    public abstract class AbstractResponseBody
    {
        [JsonPropertyName("result")]
        public string Result { set; get; } = "1";

        [JsonPropertyName("timestamp")]
        public DateTime TimeStamp { set; get; } = DateTime.UtcNow;
    }
}
