using System;
using CleanExample.Core.Products.Common;

namespace CleanExample.Core.Products.Products
{
    public class Product : Identifiable<Guid>
    {
        public Product(string name, string description = null) : this(Guid.Empty, name, description)
        {
        }

        public Product(Guid id, string name, string description = null) : base(id)
        {
            const int nameMaxLength = 50;

            Name = string.IsNullOrWhiteSpace(name)
                ? throw new ArgumentNullException(nameof(name))
                :
                name.Trim().Length > nameMaxLength
                    ?
                    throw new ArgumentException($"Argument {nameof(name)} is too long")
                    :
                    name;
            Description = description ?? string.Empty;
        }

        public string Name { get; }

        public string Description { get; }
    }
}