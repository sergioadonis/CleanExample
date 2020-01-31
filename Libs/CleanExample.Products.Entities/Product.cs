using CleanExample.Common.Entities;

namespace CleanExample.Products.Entities
{
    public class Product : AbstractEntity
    {
        public string Name { get; set; }

        public string Description { get; set; }
    }
}
