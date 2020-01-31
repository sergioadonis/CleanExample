using CleanExample.Common.Interfaces.Loggers;
using CleanExample.Common.Interfaces.Time;
using CleanExample.Common.UseCases;
using CleanExample.Common.UseCases.Models;
using CleanExample.Products.Entities;
using CleanExample.Products.UseCases.Common.Exceptions;
using CleanExample.Products.UseCases.CreateProduct.Exceptions;
using CleanExample.Products.UseCases.CreateProduct.Models;
using CleanExample.Products.UseCases.Repositories;
using System;

namespace CleanExample.Products.UseCases.CreateProduct
{
    public class UseCase : AbstractUseCase<InputModel, OutputModel>
    {
        // Injectables
        private readonly IProductRepository _repository;
        private readonly ILogger _logger;
        private readonly ITime _time;

        public UseCase(IProductRepository productRepository, ITime time, ILogger logger)
        {
            _repository = productRepository;
            _time = time;
            _logger = logger;
        }

        // TODO: Imprimir input y output en la clase base de UseCase
        public override OutputModel Use(InputModel input)
        {
            // To return
            var output = new OutputModel();
            try
            {
                _logger.Log("Starting CreateProduct use case");
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
                var max = 30;
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
                output.Status = StatusCode.Success;
                output.Message = successMessage;

            }
            catch (Exception e)
            {
                var message = $"An error occurred while executing CreateProduct use case... ";
                var data = new
                {
                    useCase = GetType().ToString(),
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