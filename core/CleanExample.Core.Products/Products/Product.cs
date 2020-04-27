using System;
using CleanExample.Core.Products.Business;
using CleanExample.Core.Products.Common;

namespace CleanExample.Core.Products.Products
{
    public class Product : Identifiable<ProductId>
    {
        public Product(ProductId id, string name, string description = null) : base(id)
        {
            const int nameMaxLength = 50;

            Name = string.IsNullOrWhiteSpace(name)
                ? throw new ArgumentNullException(nameof(name))
                : name.Trim().Length > nameMaxLength
                    ? throw new ArgumentException($"Argument {nameof(name)} is too long")
                    : name;

            Description = description ?? string.Empty;
        }

        public Product(BusinessId businessId, string code, string name, string description = null) : base(
            new ProductId(businessId, code))
        {
            const int nameMaxLength = 50;

            Name = string.IsNullOrWhiteSpace(name)
                ? throw new ArgumentNullException(nameof(name))
                : name.Trim().Length > nameMaxLength
                    ? throw new ArgumentException($"Argument {nameof(name)} is too long")
                    : name;

            Description = description ?? string.Empty;
        }

        public string Name { get; }

        public string Description { get; }
    }

    public class ProductId : IEquatable<ProductId>
    {
        public ProductId(BusinessId businessId, string code)
        {
            BusinessId = businessId ?? throw new ArgumentNullException(nameof(businessId));
            Code = code ?? throw new ArgumentNullException(nameof(code));
        }

        public string Code { get; }
        public BusinessId BusinessId { get; }

        public bool Equals(ProductId other)
        {
            if (ReferenceEquals(null, other)) return false;
            return ReferenceEquals(this, other) || (Equals(BusinessId, other.BusinessId) && Equals(Code, other.Code));
        }
    }
}