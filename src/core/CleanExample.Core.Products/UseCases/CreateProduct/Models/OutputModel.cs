using CleanExample.Core.Common.Models;
using CleanExample.Core.Products.Entities;

namespace CleanExample.Core.Products.Models
{
    public class CreateProductOutputModel : AbstractModel
    {
        public Product Product { get; set; }

        public override bool IsValid
        {
            get
            {
                return (Product != null && !string.IsNullOrEmpty(Product.Id));
            }
        }
    }
}