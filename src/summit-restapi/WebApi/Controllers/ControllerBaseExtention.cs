using Microsoft.AspNetCore.Mvc;
using System;
using System.Text.Json.Serialization;

namespace CfjSummit.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ControllerBaseExtention : ControllerBase
    {
        protected bool Authorized(string authorization)
        {
            var authorizationKey = Environment.GetEnvironmentVariable("AuthorizationKey");
            return authorizationKey != authorization;
        }

    }
    public class RequestBodyBase
    {
        [JsonPropertyName("v")]
        public string V { get; set; }

        [JsonPropertyName("uid")]
        public string Uid { get; set; }
    }
    public class ResponseBodyBase
    {
        [JsonPropertyName("result")]
        public string Result { private set; get; } = "1";

        [JsonPropertyName("timestamp")]
        public DateTime TimeStamp { private set; get; } = DateTime.UtcNow;
    }
}
