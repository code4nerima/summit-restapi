using System;
using System.ComponentModel.DataAnnotations;

namespace CfjSummit.Domain.Models.Entities
{
    public abstract class Entity
    {
        public virtual long Id { get; private set; }
        public virtual DateTime CreatedAt { get; protected set; } = DateTime.UtcNow;
        public virtual DateTime? ModifiedAt { get; protected set; } = null;
        [Timestamp]
        public byte[] TimeStamp { get; set; }

        public void SetForInsert(DateTime createdAt)
        {
            CreatedAt = createdAt;
        }
        public void SetForUpdate(DateTime modifiedAt)
        {
            ModifiedAt = modifiedAt;
        }
        protected static string NewGuid => Guid.NewGuid().ToString("N");
    }
}
