using System;
using CleanExample.Core.Products.Entities;

namespace CleanExample.Core.Products.Exceptions
{
    public sealed class BusinessDoesNotExists : Exception
    {
        public BusinessDoesNotExists(BusinessKey key) : base("Business does not exists")
        {
            Data.Add("BusinessCode", key.Code);
        }
    }
}