using System.Collections.Generic;
using System.Linq;
using CleanExample.Core.Products.Common;

namespace CleanExample.Core.Products.Products
{
    public class GetProducts : IService<object, IEnumerable<ProductDto>>
    {
        #region Invoke handler

        public IEnumerable<ProductDto> Invoke(object input = null)
        {
            _logger.Log($"Starting {GetType().FullName}");
            _logger.Log("Input model received: ", input, LogType.Debug);

            var products = _productRepository.FindAll();

            var output = new List<ProductDto>(products.Select(product => new ProductDto()
            {
                BusinessAlias = product.Id.BusinessId.Alias,
                ProductCode = product.Id.Code,
                ProductName = product.Name,
                ProductDescription = product.Description
            }));

            _logger.Log("Output model to return: ", output, LogType.Debug);
            return output;
        }

        #endregion

        #region Injectables

        private readonly IProductRepository _productRepository;
        private readonly ILogger _logger;

        public GetProducts(IProductRepository productRepository, ILogger logger)
        {
            _productRepository = productRepository;
            _logger = logger;
        }

        #endregion
    }
}