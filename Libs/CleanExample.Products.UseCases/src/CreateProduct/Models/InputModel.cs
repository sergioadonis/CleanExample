using CleanExample.Common.UseCases.Models;
using CleanExample.Products.Entities;

namespace CleanExample.Products.UseCases.CreateProduct.Models
{
    public class InputModel : BaseInputModel
    {
        public Product Product { get; set; }
    }
}