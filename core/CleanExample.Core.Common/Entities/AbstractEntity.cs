using System;

namespace CleanExample.Core.Common.Entities
{
    public abstract class AbstractEntity
    {
        public Guid Id { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }

        public DateTime DeletedAt { get; set; }
    }
}