using CleanExample.Common.Interfaces.Loggers;
using CleanExample.Common.Interfaces.Time;
using CleanExample.Common.UseCases;
using CleanExample.Common.UseCases.Models;
using CleanExample.Products.Entities;
using CleanExample.Products.UseCases.CreateProduct.Models;
using CleanExample.Products.UseCases.Repositories;
using System;

namespace CleanExample.Products.UseCases.CreateProduct
{
    public class UseCase : IUseCase<InputModel, OutputModel>
    {
        // Injectables
        private IProductRepository _repository;
        private ILogger _logger;
        private ITime _time;

        public UseCase(IProductRepository productRepository, ITime time, ILogger logger)
        {
            _repository = productRepository;
            _time = time;
            _logger = logger;
        }

        // TODO: Imprimir input y output en la clase base de UseCase
        public OutputModel Use(InputModel input)
        {
            _logger.Trace = input.Trace;
            _logger.Info("Starting CreateProduct use case");
            _logger.Debug("Input model received: ", input);

            // Business rules example
            // -----------------------------------------------------------------
            // Clean data
            input.Product.Name = string.IsNullOrWhiteSpace(input.Product.Name) ? "" : input.Product.Name.Trim();
            input.Product.Description = string.IsNullOrWhiteSpace(input.Product.Description) ? "" : input.Product.Description.Trim();
            input.Product.CreatedAt = _time.GetCurrentTime();

            // Validations
            if (string.IsNullOrEmpty(input.Product.Name))
            {
                var message = $"Product name is empty";
                _logger.Warn(message);
                return new OutputModel()
                {
                    Status = StatusCode.BusinessRulesError,
                    Message = message
                };
            }

            var exists = _repository.FindByName(input.Product.Name);
            if (exists != null)
            {
                var message = $"Product with this name already exists";
                _logger.Warn(message);
                return new OutputModel()
                {
                    Status = StatusCode.BusinessRulesError,
                    Message = message
                };
            }

            var nameLength = input.Product.Name.Length;
            var max = 30;
            if (nameLength > max)
            {
                var message = $"Product name length: {nameLength}. Max length allowed: {max}";
                _logger.Warn(message);
                return new OutputModel()
                {
                    Status = StatusCode.BusinessRulesError,
                    Message = message
                };
            }

            // -----------------------------------------------------------------
            // End of business rules


            // Persistence
            Product product = null;
            try
            {
                product = _repository.Create(input.Product);
            }
            catch (Exception e)
            {
                _logger.Error(e.Message);
                return new OutputModel()
                {
                    Status = StatusCode.DatabaseError,
                    Message = e.Message
                };
            }

            if (product == null)
            {
                var message = "Product not created... ProductRepository returns null";
                _logger.Warn(message);
                return new OutputModel()
                {
                    Status = StatusCode.DatabaseError,
                    Message = message
                };
            }

            // Success
            var successMessage = $"Product with id {product.Id} was created successfully!";
            _logger.Info(successMessage, product);
            return new OutputModel()
            {
                Status = StatusCode.Success,
                Product = product,
                Message = successMessage
            };
        }
    }
}