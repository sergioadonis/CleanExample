using System.Collections.Generic;
using System.Linq;
using CleanExample.Core.Products.Contracts;
using CleanExample.Core.Products.Dto;
using CleanExample.Core.Products.Exceptions;
using CleanExample.Core.Products.Mappers;

namespace CleanExample.Core.Products.Services
{
    public class GetProductsByBusiness : IService<BusinessKeyDto, IEnumerable<ProductDto>>
    {
        #region Invoke handler

        public IEnumerable<ProductDto> Invoke(BusinessKeyDto input)
        {
            _logger.Log($"Starting {GetType().FullName}");
            _logger.Log("Input model received: ", input, LogType.Debug);

            var businessKey = BusinessMapper.ToBusinessKey(input);
            var business = _businessRepository.Find(businessKey);
            if (business == null)
            {
                var error = new BusinessDoesNotExists(businessKey);
                _logger.Log(error.Message, businessKey, LogType.Error);
                throw error;
            }

            var products = _productRepository.FindByBusiness(businessKey);

            var output = new List<ProductDto>(products.Select(product => new ProductDto()
            {
                BusinessCode = business.Code,
                ProductCode = product.Code,
                ProductName = product.Name,
                ProductDescription = product.Description
            }));

            _logger.Log("Output model to return: ", output, LogType.Debug);
            return output;
        }

        #endregion

        #region Injectables

        private readonly IProductRepository _productRepository;
        private readonly IBusinessRepository _businessRepository;
        private readonly ILogger _logger;

        public GetProductsByBusiness(IProductRepository productRepository, IBusinessRepository businessRepository,
            ILogger logger)
        {
            _productRepository = productRepository;
            _businessRepository = businessRepository;
            _logger = logger;
        }

        #endregion
    }
}