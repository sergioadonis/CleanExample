using CleanExample.Core.Products.Dto;
using CleanExample.Core.Products.Entities;

namespace CleanExample.Core.Products.Mappers
{
    public static class ProductMapper
    {
        private static BusinessKey ToBusinessKey(ProductDto productDto) => new BusinessKey(productDto.BusinessCode);

        private static ProductKey ToProductKey(ProductDto productDto) =>
            new ProductKey(productDto.ProductCode, ToBusinessKey(productDto));

        public static Product ToProduct(ProductDto productDto) => new Product(ToProductKey(productDto),
            productDto.ProductName, productDto.ProductDescription);
    }
}