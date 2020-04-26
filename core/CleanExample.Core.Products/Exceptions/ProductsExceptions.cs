using System;

namespace CleanExample.Core.Products.Exceptions
{
    public sealed class ProductNameAlreadyExistsException : Exception
    {
        public ProductNameAlreadyExistsException(string name) : base("A product with that name already exists")
        {
            Data.Add("ProductName", name);
        }
    }
}