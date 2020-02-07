using System;

namespace CleanExample.Core.Common.Entities
{
    public abstract class AbstractEntity
    {
        public string Id;

        public DateTime CreatedAt;

        public DateTime UpdatedAt;

        public DateTime DeletedAt;
    }
}