using CleanExample.Core.Common.Entities;
using CleanExample.Core.Common.ValueObjects;
using System;

namespace CleanExample.Core.Products.Entities
{
    public class Product : AbstractEntity
    {
        public Product(Name name, string description = "")
        {
            Id = Guid.Empty;
            Name = name;
            Description = description;
        }

        public Product(Guid id, Name name, string description = "")
        {
            Id = id;
            Name = name;
            Description = description;
        }

        public Name Name { get; set; }

        public string Description { get; set; }        
    }
}
