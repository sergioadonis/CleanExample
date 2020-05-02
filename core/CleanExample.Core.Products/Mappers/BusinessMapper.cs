using CleanExample.Core.Products.Dto;
using CleanExample.Core.Products.Entities;

namespace CleanExample.Core.Products.Mappers
{
    public static class BusinessMapper
    {
        public static BusinessKey ToBusinessKey(BusinessKeyDto businessKeyDto) => new BusinessKey(businessKeyDto.Code);
    }
}