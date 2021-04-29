using System;
using System.Text.Json.Serialization;

namespace CfjSummit.WebApi.Interfaces
{
    public abstract class AbstractResponseBody
    {
        [JsonPropertyName("result")]
        public string Result { set; get; }

        [JsonPropertyName("timestamp")]
        public DateTime TimeStamp { set; get; }
    }
}
