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

        //private string Uid { get; private set; }
        public virtual Program Program { get; private set; }
        public UserProfile UserProfile { private set; get; }
        //public virtual string Uid { get; private set; }
    }
}
