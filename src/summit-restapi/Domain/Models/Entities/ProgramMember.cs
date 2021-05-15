namespace CfjSummit.Domain.Models.Entities
{
    public class ProgramMember : Entity
    {
        protected ProgramMember()
        {

        }
        public ProgramMember(UserProfile userProfile)
        {
            UserProfile = userProfile;
        }

        public virtual Program Program { get; private set; }
        public UserProfile UserProfile { private set; get; }

    }
}
