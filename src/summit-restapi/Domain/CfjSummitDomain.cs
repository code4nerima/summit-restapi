using System.Reflection;

namespace CfjSummit.Domain
{
    public static class CfjSummitDomain
    {
        public static Assembly Assembly { get => (typeof(CfjSummitDomain)).GetTypeInfo().Assembly; }
    }
}
