using CleanExample.Core.Products.Entities;

namespace CleanExample.Core.Products.Dto
{
    public sealed class ProductDto
    {
        public string BusinessCode { get; set; }
        public string ProductCode { get; set; }
        public string ProductName { get; set; }
        public string ProductDescription { get; set; }

        public Product ToProduct() =>
            new Product(ProductCode, BusinessCode, ProductName, ProductDescription);
    }
}