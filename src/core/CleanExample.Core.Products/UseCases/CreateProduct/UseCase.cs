using CleanExample.Core.Common.Loggers;
using CleanExample.Core.Common.Time;
using CleanExample.Core.Common.UseCases;
using CleanExample.Core.Products.Entities;
using CleanExample.Core.Products.Exceptions;
using CleanExample.Core.Products.Repositories;
using CleanExample.Core.Products.Models;
using System;

namespace CleanExample.Core.Products.UseCases
{
    public class CreateProductUseCase : IUseCase<CreateProductInputModel, CreateProductOutputModel>
    {
        // Injectables
        private readonly IProductRepository _repository;
        private readonly ILogger _logger;
        private readonly ITime _time;

        public CreateProductUseCase(IProductRepository productRepository, ITime time, ILogger logger)
        {
            _repository = productRepository;
            _time = time;
            _logger = logger;
        }

        // TODO: Imprimir input y output en la clase base de UseCase
        public CreateProductOutputModel Use(CreateProductInputModel input)
        {
            // To return
            var output = new CreateProductOutputModel();
            try
            {
                _logger.Log("Starting CreateProduct.UseCase");
                _logger.Log("Input model received: ", input, LogType.DEBUG);

                #region Business rules example
                // Clean data
                input.Product.Name = string.IsNullOrWhiteSpace(input.Product.Name) ? "" : input.Product.Name.Trim();
                input.Product.Description = string.IsNullOrWhiteSpace(input.Product.Description) ? "" : input.Product.Description.Trim();
                input.Product.CreatedAt = _time.GetCurrentTime();

                // Validations
                if (string.IsNullOrEmpty(input.Product.Name))
                    throw new ProductNameIsEmptyException();

                var exists = _repository.FindByName(input.Product.Name);
                if (exists != null)
                    throw new ProductNameAlreadyExistsException(input.Product.Name);

                var nameLength = input.Product.Name.Length;
                var max = 50;
                if (nameLength > max)
                    throw new ProductNameIsTooLongException(input.Product.Name, max);
                #endregion

                #region Persistence
                Product product = null;
                try
                {
                    product = _repository.Create(input.Product);
                }
                catch (Exception e)
                {
                    throw new ProductRepositoryCreateException(e);
                }

                if (product == null)
                {
                    var message = $"Product not created... The function _repository.Create(input.Product) returns null. _repository type: {_repository.GetType().ToString()}";
                    var e = new Exception(message);
                    throw new ProductRepositoryCreateException(e);
                }
                #endregion

                // Success
                var successMessage = $"Product with id {product.Id} was created successfully!";
                _logger.Log(successMessage, product);
                output.Product = product;

            }
            catch (Exception e)
            {
                var message = $"An error occurred while executing a service... {GetType().FullName}";
                var data = new
                {
                    service = GetType().FullName,
                    input,
                    output,
                    exception = e
                };
                _logger.Log(message, data, LogType.ERROR);
                throw e;

                //output.Status = StatusCode.BusinessRulesError;
                //output.Message = e.Message;
            }

            // Return
            _logger.Log("Output model to return: ", output, LogType.DEBUG);
            return output;
        }
    }
}