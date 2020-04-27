using CleanExample.Core.Products.Business;

namespace CleanExample.Core.Products.Products
{
    public sealed class ProductDto
    {
        public string BusinessAlias { get; set; }
        public string ProductCode { get; set; }
        public string ProductName { get; set; }
        public string ProductDescription { get; set; }

        public Product ToProduct() =>
            new Product(new BusinessId(BusinessAlias), ProductCode, ProductName, ProductDescription);
    }
}