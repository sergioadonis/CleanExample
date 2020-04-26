using System;
using CleanExample.Core.Products.Common;

namespace CleanExample.Core.Products.Products
{
    public class Product : AbstractEntity
    {
        private const int MaxLength = 50;

        public Product(string name, string description = null) : this(Guid.Empty, name, description)
        {
        }

        public Product(Guid id, string name, string description = null)
        {
            Id = id;
            name = CleanWhiteSpace(name);
            Name = string.IsNullOrEmpty(name) ? throw new ArgumentNullException(nameof(name)) :
                name.Length > MaxLength ? throw new ArgumentException("Name is too long", nameof(name)) : name;
            Description = CleanWhiteSpace(description);
        }

        public string Name { get; private set; }

        public string Description { get; private set; }
    }
}