using CleanExample.Common.Services.Models;
using CleanExample.Products.Entities;

namespace CleanExample.Products.Services.CreateProduct.Models
{
    public class OutputModel : AbstractOutputModel
    {
        public Product Product { get; set; }
    }
}