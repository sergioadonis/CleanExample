using System;
using CleanExample.Products.Entities;
using CleanExample.Common.UseCases.Models;

namespace CleanExample.Products.UseCases.CreateProduct.Models
{
    public class OutputModel : BaseOutputModel
    {
        public Product Product { get; set; }
    }
}