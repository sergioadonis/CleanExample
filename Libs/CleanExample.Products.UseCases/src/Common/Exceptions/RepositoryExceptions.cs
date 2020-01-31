using System;

namespace CleanExample.Products.UseCases.Common.Exceptions
{
    public class ProductRepositoryCreateException : Exception
    {
        public ProductRepositoryCreateException(Exception innerException) : base($"An error occurred while executing the Create() operation of IProductRepository", innerException) { }
    }
}
