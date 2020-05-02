using System;

namespace CleanExample.Core.Products.Entities
{
    public class Product : Entity<ProductKey>
    {
        public Product(ProductKey productKey, string name, string description = null) : base(productKey)
        {
            const int nameMaxLength = 50;
            Name = string.IsNullOrWhiteSpace(name)
                ? throw new ArgumentNullException(nameof(name))
                : name.Trim().Length > nameMaxLength
                    ? throw new ArgumentException($"Argument {nameof(name)} is too long")
                    : name;

            Description = description ?? string.Empty;
        }

        public Product(string productCode, string businessCode, string name, string description = null) : this(
            new ProductKey(productCode, new BusinessKey(businessCode)), name, description)
        {
        }

        public Product(string productCode, BusinessKey businessKey, string name, string description = null) : this(
            new ProductKey(productCode, businessKey), name, description)
        {
        }

        public string Code => Key.Code;

        public BusinessKey BusinessKey => Key.BusinessKey;

        public string BusinessCode => BusinessKey.Code;

        public string Name { get; }

        public string Description { get; }
    }

    public class ProductKey : IEquatable<ProductKey>
    {
        public ProductKey(string code, BusinessKey businessKey)
        {
            Code = code;
            BusinessKey = businessKey;
        }

        public string Code { get; }

        public BusinessKey BusinessKey { get; }

        public bool Equals(ProductKey other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return Code == other.Code && BusinessKey == other.BusinessKey;
        }
    }
}