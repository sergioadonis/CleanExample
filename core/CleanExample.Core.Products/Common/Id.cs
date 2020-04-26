using System;

namespace CleanExample.Core.Products.Common
{
    public abstract class Id : IEquatable<Id>
    {
        public bool Equals(Id other)
        {
            throw new NotImplementedException();
        }

        public override bool Equals(Object other)
        {
            throw new NotImplementedException();
        }

        public override int GetHashCode()
        {
            throw new NotImplementedException();
        }

        public static bool operator ==(Id a, Id b)
        {
            if (ReferenceEquals(a, b)) return true;
            if (((object) a == null) || ((object) b == null)) return false;

            return a == b;
        }

        public static bool operator !=(Id a, Id b) => !(a == b);
    }
}