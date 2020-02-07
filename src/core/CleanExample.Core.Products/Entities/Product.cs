using CleanExample.Core.Common.Entities;

namespace CleanExample.Core.Products.Entities
{
    public class Product : AbstractEntity
    {
        public string Name { get; set; }

        public string Description { get; set; }
    }
}
