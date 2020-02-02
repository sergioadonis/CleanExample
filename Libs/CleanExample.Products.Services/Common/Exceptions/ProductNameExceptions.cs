using System;

namespace CleanExample.Products.Services.Common.Exceptions
{
    public class ProductNameIsEmptyException : Exception
    {
        public ProductNameIsEmptyException() : base("Product name is empty") { }
    }

    public class ProductNameAlreadyExistsException : Exception
    {
        public ProductNameAlreadyExistsException(string name) : base($"A product with that name already exists")
        {
            Data.Add("ProductName", name);
        }
    }

    public class ProductNameIsTooLongException : Exception
    {
        public ProductNameIsTooLongException(string name, int maxAllowed) : base("Product name is too long")
        {
            Data.Add("ProductName", name);
            Data.Add("ProductNameLength", name.Length);
            Data.Add("MaxLengthAllowed", maxAllowed);
        }
    }
}
