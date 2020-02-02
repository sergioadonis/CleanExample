using CleanExample.Common.Services.Models;

namespace CleanExample.Common.Services.UseCases
{
    public interface IUseCase<TInputModel, TOutputModel> where TInputModel : AbstractInputModel where TOutputModel : AbstractOutputModel
    {
        TOutputModel Use(TInputModel input);
    }
}