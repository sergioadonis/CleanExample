using System.Collections.Generic;
using CleanExample.Core.Products.Common;

namespace CleanExample.Core.Products.Products
{
    public class GetProducts : IService<Empty, GetProducts.Output>
    {
        #region Invoke handler

        public Output Invoke(Empty input = null)
        {
            _logger.Log($"Starting {GetType().FullName}");
            _logger.Log("Input model received: ", input, LogType.Debug);

            var products = _productRepository.FindAll();

            var output = new Output
            {
                Products = products
            };

            _logger.Log("Output model to return: ", output, LogType.Debug);
            return output;
        }

        #endregion

        #region Input/Output Models

        public class Output
        {
            public IEnumerable<Product> Products { get; set; }
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