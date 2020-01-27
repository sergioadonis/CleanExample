using System;
using CleanExample.Products.Entities;
using CleanExample.Common.UseCases.Models;

namespace CleanExample.Products.UseCases.CreateProduct.Models
{
    public class InputModel : BaseInputModel
    {
        public Product Product { get; set; }
    }
}