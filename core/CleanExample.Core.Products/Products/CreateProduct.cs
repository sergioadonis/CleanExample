﻿using System;
using CleanExample.Core.Products.Common;

namespace CleanExample.Core.Products.Products
{
    public class CreateProduct : IService<CreateProduct.InputModel, CreateProduct.OutputModel>
    {
        #region Handler

        public OutputModel Invoke(InputModel input)
        {
            _logger.Log($"Starting {GetType().FullName}");
            _logger.Log("Input model received: ", input, LogType.Debug);

            #region Business rules example

            // Validations
            var exists = _repository.FindByName(input.Name);
            if (exists != null)
                throw new ProductNameAlreadyExists(input.Name);

            #endregion

            #region Persistence

            // Initializing
            var product = new Product(Guid.NewGuid(), input.Name, input.Description);
            var created = _repository.Create(product);

            var message = created
                ? $"Product with id {product.Id} was created successfully by _repository type: {_repository.GetType()}!"
                : $"Product wasn't created... The function _repository.Create(product) returned false. _repository type: {_repository.GetType()}.";
            _logger.Log(message);

            // To return
            var output = new OutputModel
            {
                Id = created ? product.Id : Guid.Empty
            };

            _logger.Log("Output model to return: ", output, LogType.Debug);
            return output;

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


        #region Input/Output models

        public class InputModel
        {
            public string Name { get; set; }
            public string Description { get; set; }
        }

        public class OutputModel
        {
            public Guid Id { get; set; }
            public bool Created => (Id != Guid.Empty);
        }

        #endregion
    }
}