using CleanExample.Core.Products.Contracts;
using CleanExample.Core.Products.Dto;
using CleanExample.Core.Products.Exceptions;
using CleanExample.Core.Products.Mappers;

namespace CleanExample.Core.Products.Services
{
    public class CreateProduct : IService<ProductDto, CreatedDto>
    {
        #region Invoke handler

        public CreatedDto Invoke(ProductDto input)
        {
            _logger.Log($"Starting {GetType().FullName}");
            _logger.Log("Input model received: ", input, LogType.Debug);

            #region Business rules example

            var product = ProductMapper.ToProduct(input);
            var business = _businessRepository.Find(product.BusinessKey);
            if (business == null)
            {
                var error = new BusinessDoesNotExists(product.BusinessKey);
                _logger.Log(error.Message, product.BusinessKey, LogType.Error);
                throw error;
            }

            // Validations
            var exists = _repository.FindByCodeOrName(product.BusinessKey, product.Code, product.Name);
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
                ? $"Product with Code {product.Code} was created successfully by _repository type: {_repository.GetType()}!"
                : $"Product wasn't created... The function _repository.Create(product) returned false. _repository type: {_repository.GetType()}.";
            _logger.Log(message);

            // To return
            var output = new CreatedDto() {Created = created};
            _logger.Log("Output model to return: ", output, LogType.Debug);
            return output;

            #endregion
        }

        #endregion


        #region Injectables

        private readonly IProductRepository _repository;
        private readonly IBusinessRepository _businessRepository;
        private readonly ILogger _logger;

        public CreateProduct(IProductRepository productRepository, IBusinessRepository businessRepository,
            ILogger logger)
        {
            _repository = productRepository;
            _businessRepository = businessRepository;
            _logger = logger;
        }

        #endregion
    }
}