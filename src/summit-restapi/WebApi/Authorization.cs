using System;

namespace CfjSummit.WebApi
{
    public static class Authorization
    {
        public static bool Authorized(string authorization)
        {
            var authorizationKey = Environment.GetEnvironmentVariable("AuthorizationKey");
            return authorizationKey == authorization;
        }
    }
}
