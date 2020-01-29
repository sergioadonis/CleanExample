using CleanExample.Common.UseCases.Models;
using CleanExample.Products.Entities;

namespace CleanExample.Products.UseCases.CreateProduct.Models
{
    public class OutputModel : BaseOutputModel
    {
        public Product Product { get; set; }
    }
}