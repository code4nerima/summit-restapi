using CfjSummit.Domain.Services.Domain;
using CfjSummit.WebApi.Interfaces;
using Microsoft.AspNetCore.Http;
using System.Text.Json;

namespace CfjSummit.WebApi
{
    public static class Logger
    {
        public static CreateRequestLogCommand CreateWriteLogCommand(HttpRequest request, object requestBody)
        {
            var uid = (requestBody as AbstractRequestBody).Uid;
            var json = JsonSerializer.Serialize(requestBody);
            var cmd = new CreateRequestLogCommand(uid,
                                                  request.Method,
                                                  request.RouteValues["controller"].ToString(),
                                                  request.ContentType,
                                                  json,
                                                  request.HttpContext.Connection.LocalIpAddress.ToString(),
                                                  request.HttpContext.Connection.RemoteIpAddress.ToString());
            return cmd;
        }
    }
}
