using System;

namespace CleanExample.Core.Products.Entities
{
    public abstract class Entity<TKey> : IEquatable<Entity<TKey>> where TKey : IEquatable<TKey>
    {
        protected Entity(TKey key)
        {
            Key = key;
        }

        public TKey Key { get; }

        public bool Equals(Entity<TKey> other)
        {
            if (ReferenceEquals(null, other)) return false;
            return ReferenceEquals(this, other) || Equals(Key, other.Key);
        }
    }
}