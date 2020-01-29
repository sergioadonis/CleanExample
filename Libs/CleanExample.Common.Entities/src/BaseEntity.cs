using System;

namespace CleanExample.Common.Entities
{
    public abstract class BaseEntity : IEntity
    {
        public string Id;

        public DateTime CreatedAt;

        public DateTime UpdatedAt;

        public DateTime DeletedAt;
    }
}