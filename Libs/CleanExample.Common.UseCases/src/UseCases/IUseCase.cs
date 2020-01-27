using System;
using CleanExample.Common.UseCases.Models;

namespace CleanExample.Common.UseCases
{
    public interface IUseCase<TInputModel, TOutputModel> where TInputModel : IModel where TOutputModel : IModel
    {
        TOutputModel Use(TInputModel input);
    }
}