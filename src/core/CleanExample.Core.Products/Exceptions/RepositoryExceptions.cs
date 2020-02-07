using System;

namespace CleanExample.Core.Products.Exceptions
{
    public class ProductRepositoryCreateException : Exception
    {
        public ProductRepositoryCreateException(Exception innerException) : base($"An error occurred while executing the Create() operation of IProductRepository", innerException) { }
    }
}
