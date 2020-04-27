using System;

namespace CleanExample.Core.Products.Products
{
    public sealed class ProductAlreadyExists : Exception
    {
        public ProductAlreadyExists(Product product) : base("This product already exists")
        {
            Data.Add("BusinessAlias", product.Id.BusinessId.Alias);
            Data.Add("ProductCode", product.Id.Code);
            Data.Add("ProductName", product.Name);
        }
    }
}