using CleanExample.Common.Services.Models;
using CleanExample.Products.Entities;

namespace CleanExample.Products.Services.CreateProduct.Models
{
    public class InputModel : AbstractInputModel
    {
        public Product Product { get; set; }
    }
}