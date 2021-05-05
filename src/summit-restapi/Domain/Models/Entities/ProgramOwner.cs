namespace CfjSummit.Domain.Models.Entities
{
    public class ProgramOwner : Entity
    {
        protected ProgramOwner()
        {

        }
        public ProgramOwner(UserProfile userProfile)
        {
            UserProfile = userProfile;
        }

        public virtual Program Program { get; private set; }
        public UserProfile UserProfile { private set; get; }
    }
}
