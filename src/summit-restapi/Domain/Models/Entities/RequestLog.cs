namespace CfjSummit.Domain.Models.Entities
{
    public class RequestLog : Entity
    {
        protected RequestLog()
        {

        }
        public RequestLog(string uid, string method, string controller, string contentType,
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
        public virtual string Uid { get; private set; }
        public virtual string Method { get; private set; }
        public virtual string Controller { get; private set; }
        public virtual string ContentType { get; private set; }
        public virtual string RequestBody { get; private set; }
        public virtual string LocalIpAddress { get; private set; }
        public virtual string RemoteIpAddress { get; private set; }
    }
}
