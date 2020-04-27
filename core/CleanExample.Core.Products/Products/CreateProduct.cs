using CleanExample.Core.Products.Common;

namespace CleanExample.Core.Products.Products
{
    public class CreateProduct : IService<ProductDto, bool>
    {
        #region Invoke handler

        public bool Invoke(ProductDto input)
        {
            _logger.Log($"Starting {GetType().FullName}");
            _logger.Log("Input model received: ", input, LogType.Debug);

            #region Business rules example

            var product = input.ToProduct();

            // Validations
            var exists = _repository.FindByCodeOrName(product.Id.BusinessId, product.Id.Code, product.Name);
            if (exists != null)
            {
                var error = new ProductAlreadyExists(product);
                _logger.Log(error.Message, product, LogType.Error);
                throw error;
            }

            #endregion

            #region Persistence

            var created = _repository.Insert(product);

            var message = created
                ? $"Product with Code {product.Id.Code} was created successfully by _repository type: {_repository.GetType()}!"
                : $"Product wasn't created... The function _repository.Create(product) returned false. _repository type: {_repository.GetType()}.";
            _logger.Log(message);
            _logger.Log("Output model to return: ", created, LogType.Debug);
            return created;

            #endregion
        }

        #endregion


        #region Injectables

        private readonly IProductRepository _repository;
        private readonly ILogger _logger;

        public CreateProduct(IProductRepository productRepository, ILogger logger)
        {
            _repository = productRepository;
            _logger = logger;
        }

        #endregion
    }
}