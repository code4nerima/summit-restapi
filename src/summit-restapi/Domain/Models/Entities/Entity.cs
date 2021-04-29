using System;
using System.ComponentModel.DataAnnotations;

namespace CfjSummit.Domain.Models.Entities
{
    public abstract class Entity
    {
        public virtual long Id { get; private set; }
        public virtual string CreateUid { get; protected set; }
        public virtual DateTime CreatedAt { get; protected set; }
        public virtual string ModifyUid { get; protected set; } = null;
        public virtual DateTime? ModifiedAt { get; protected set; }
        [Timestamp]
        public byte[] TimeStamp { get; set; }

        public void SetForInsert(string uid, DateTime createdAt)
        {
            CreateUid = uid;
            CreatedAt = createdAt;
        }
        public void SetForUpdate(string uid, DateTime modifiedAt)
        {
            ModifyUid = uid;
            ModifiedAt = modifiedAt;
        }
    }
}
