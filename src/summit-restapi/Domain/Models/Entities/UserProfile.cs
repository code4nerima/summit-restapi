using CfjSummit.Domain.Models.Enums;

namespace CfjSummit.Domain.Models.Entities
{
    public class UserProfile : Entity
    {
        public UserProfile(string uid, string name, UserRole userRole)
        {
            Uid = uid;
            Name = name;
            Role = (int)userRole;
        }
        public virtual string Uid { get; private set; }
        public virtual string Name { get; private set; }
        public virtual int Role { get; private set; }
    }
}
