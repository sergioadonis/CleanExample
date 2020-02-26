using CleanExample.Core.Common.Models;
using CleanExample.Core.Products.Entities;
using System;

namespace CleanExample.Core.Products.Models
{
    public class CreateProductOutputModel : AbstractModel
    {
        public Product Product { get; set; }

        public override bool IsValid
        {
            get
            {
                return (Product != null && Product.Id != Guid.Empty);
            }
        }
    }
}