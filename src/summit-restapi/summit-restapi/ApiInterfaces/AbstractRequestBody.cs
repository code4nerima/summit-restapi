using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace summit_restapi.ApiInterfaces
{
    public abstract class AbstractRequestBody
    {
        [JsonPropertyName("v")]
        public string V { get; set; }

        [JsonPropertyName("uid")]
        public string Uid { get; set; }

    }
}
