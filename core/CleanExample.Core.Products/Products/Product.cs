using System;
using CleanExample.Core.Products.Common;

namespace CleanExample.Core.Products.Products
{
    public class Product : Identifiable<Guid>
    {
        private const int MaxLength = 50;

        public Product(string name, string description = null) : this(Guid.Empty, name, description)
        {
        }

        public Product(Guid id, string name, string description = null) : base(id)
        {
            name = CleanWhiteSpace(name);
            Name = string.IsNullOrEmpty(name) ? throw new ArgumentNullException(nameof(name)) :
                name.Length > MaxLength ? throw new ArgumentException("Name is too long", nameof(name)) : name;
            Description = CleanWhiteSpace(description);
        }

        public string Name { get; }

        public string Description { get; }

        private static string CleanWhiteSpace(string value) =>
            string.IsNullOrWhiteSpace(value) ? string.Empty : value.Trim();
    }
}