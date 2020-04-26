using System;

namespace CleanExample.Core.Products.Products
{
    public sealed class ProductNameAlreadyExists : Exception
    {
        public ProductNameAlreadyExists(string name) : base("A product with that name already exists")
        {
            Data.Add("ProductName", name);
        }
    }
}