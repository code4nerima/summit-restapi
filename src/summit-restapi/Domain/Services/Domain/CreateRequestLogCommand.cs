using MediatR;

namespace CfjSummit.Domain.Services.Domain
{
    public class CreateRequestLogCommand : IRequest<int>
    {
        public string Uid { get; set; }
        public string Method { get; set; }
        public string Controller { get; set; }
        public string ContentType { get; set; }
        public string RequestBody { get; set; }
        public string LocalIpAddress { get; set; }
        public string RemoteIpAddress { get; set; }

        public CreateRequestLogCommand(string uid, string method, string controller, string contentType,
            string requestBody, string localIpAddress, string remoteIpAddress)
        {
            Uid = uid;
            Method = method;
            Controller = controller;
            ContentType = contentType;
            RequestBody = requestBody;
            LocalIpAddress = localIpAddress;
            RemoteIpAddress = remoteIpAddress;
        }
    }
}
