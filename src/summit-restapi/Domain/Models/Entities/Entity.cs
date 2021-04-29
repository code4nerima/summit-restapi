using System;

namespace CfjSummit.Domain.Models.Entities
{
    public abstract class Entity
    {
        public virtual long Id { get; private set; }
        public virtual string ModifyUid { get; protected set; }
        public virtual string CreateUid { get; protected set; }
        public virtual DateTime CreatedAt { get; protected set; }
        public virtual DateTime ModifiedAt { get; protected set; }
    }
}
