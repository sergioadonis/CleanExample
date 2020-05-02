using CleanExample.Core.Products.Entities;

namespace CleanExample.Core.Products.Dto
{
    public class BusinessKeyDto
    {
        public string Code { get; set; }

        public BusinessKey ToBusinessKey() => new BusinessKey(Code);
    }
}