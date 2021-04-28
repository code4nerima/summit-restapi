using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace summit_restapi.ApiInterfaces
{
    public abstract class AbstractResponseBody
    {
        [JsonPropertyName("result")]
        public string Result { set; get; }

        [JsonPropertyName("timestamp")]
        public DateTime TimeStamp { set; get; }

    }
}
