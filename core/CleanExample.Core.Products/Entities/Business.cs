using System;

namespace CleanExample.Core.Products.Entities
{
    public class Business : Entity<BusinessKey>
    {
        public Business(BusinessKey businessKey, string name) : base(businessKey)
        {
            Name = name ?? throw new ArgumentNullException(nameof(name));
        }

        public Business(string businessCode, string name) : this(new BusinessKey(businessCode), name)
        {
        }

        public string Code => Key.Code;
        public string Name { get; }
    }

    public class BusinessKey : IEquatable<BusinessKey>
    {
        public BusinessKey(string code)
        {
            Code = code;
        }

        public string Code { get; }

        public bool Equals(BusinessKey other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return Code == other.Code;
        }
    }
}