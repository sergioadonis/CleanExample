using CleanExample.Common.Services.Models;
using CleanExample.Products.Entities;

namespace CleanExample.Products.Services.CreateProduct.Models
{
    public class OutputModel : AbstractModel
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