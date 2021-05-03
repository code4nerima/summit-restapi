using System;
using System.Text.Json.Serialization;

namespace CfjSummit.WebApi.Interfaces
{
    public abstract class AbstractResponseBody
    {
        [JsonPropertyName("result")]
        public string Result { get; } = "1";

        [JsonPropertyName("timestamp")]
        public DateTime TimeStamp { get; } = DateTime.UtcNow;
    }
}
