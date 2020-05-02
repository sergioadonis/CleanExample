using System;
using CleanExample.Core.Products.Entities;

namespace CleanExample.Core.Products.Exceptions
{
    public sealed class ProductAlreadyExists : Exception
    {
        public ProductAlreadyExists(Product product) : base("This product already exists")
        {
            Data.Add("Code", product.Code);
            Data.Add("ProductName", product.Name);
        }
    }
}