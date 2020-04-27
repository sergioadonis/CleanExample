using System;
using CleanExample.Core.Products.Common;

namespace CleanExample.Core.Products.Business
{
    public class Business : Identifiable<BusinessId>
    {
        public Business(BusinessId id) : base(id)
        {
        }

        public Business(BusinessId id, string name) : base(id)
        {
            Name = name ?? throw new ArgumentNullException(nameof(name));
        }

        public string Name { get; }
    }

    public class BusinessId : IEquatable<BusinessId>
    {
        public BusinessId(string alias)
        {
            Alias = alias ?? throw new ArgumentNullException(nameof(alias));
        }

        public string Alias { get; }

        public bool Equals(BusinessId other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return Alias == other.Alias;
        }
    }
}