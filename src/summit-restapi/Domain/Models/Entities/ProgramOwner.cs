namespace CfjSummit.Domain.Models.Entities
{
    public class ProgramOwner : Entity
    {
        protected ProgramOwner()
        {

        }
        public ProgramOwner(string uid)
        {
            Uid = uid;
        }
        public virtual Program Program { get; private set; }
        public virtual string Uid { get; private set; }
    }
}
