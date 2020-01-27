using System;
using CleanExample.Common.Interfaces.Time;
using CleanExample.Common.Interfaces.Loggers;
using CleanExample.Common.UseCases;
using CleanExample.Common.UseCases.Models;
using CleanExample.Products.Entities;
using CleanExample.Products.Interfaces.Repositories;
using CleanExample.Products.UseCases.CreateProduct.Models;

namespace CleanExample.Products.UseCases.CreateProduct
{
    public class UseCase : IUseCase<InputModel, OutputModel>
    {
        // Injectables
        private IProductRepository repository;
        private ILogger logger;
        private ITime time;
        
        public UseCase(IProductRepository productRepository, ITime time, ILogger logger)
        {
            this.repository = productRepository;
            this.time = time;
            this.logger = logger;
        }
        
        public OutputModel Use(InputModel input)
        {
            logger.Info("Starting CreateProduct use case");
            logger.Debug("Input model received: " + input);
            
            // Business rules example
            // -----------------------------------------------------------------
            // Clean data
            input.Product.Name = string.IsNullOrWhiteSpace(input.Product.Name) ? "" : input.Product.Name.Trim();
            input.Product.Description = string.IsNullOrWhiteSpace(input.Product.Description) ? "" : input.Product.Description.Trim();
            input.Product.CreatedAt = time.GetCurrentTime();
            
            // Validations
            if (string.IsNullOrEmpty(input.Product.Name))
            {
                var message = $"Product name is empty";
                logger.Warn(message);
                return new OutputModel()
                {
                    Status = StatusCode.BusinessRulesError,
                    Message = message
                };
            }
            
            var exists = repository.FindByName(input.Product.Name);
            if (exists != null) 
            {
                var message = $"Product with this name already exists";
                logger.Warn(message);
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
                logger.Warn(message);
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
                product = repository.Create(input.Product);
            }
            catch(Exception e)
            {
                logger.Error(e.Message);
                return new OutputModel()
                {
                    Status = StatusCode.DatabaseError,
                    Message = e.Message
                };
            }
            
            if (product == null)
            {
                var message = "Product not created... ProductRepository returns null";
                logger.Warn(message);
                return new OutputModel()
                {
                    Status = StatusCode.DatabaseError,
                    Message = message
                };
            }
            
            // Success
            var successMessage = $"Product with id {product.Id} was created successfully!";
            logger.Info(successMessage);
            return new OutputModel()
            {
                Status = StatusCode.Success,
                Product = product,
                Message = successMessage
            };
        }
    }
}