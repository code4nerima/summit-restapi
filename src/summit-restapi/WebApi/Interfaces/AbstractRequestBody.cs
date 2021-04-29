using System.Text.Json.Serialization;

namespace CfjSummit.WebApi.Interfaces
{
    public abstract class AbstractRequestBody
    {
        [JsonPropertyName("v")]
        public string V { get; set; }

        [JsonPropertyName("uid")]
        public string Uid { get; set; }
    }
}
