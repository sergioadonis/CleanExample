using CleanExample.Common.UseCases.Models;

namespace CleanExample.Common.UseCases
{
    public interface IUseCase<TInputModel, TOutputModel> where TInputModel : AbstractInputModel where TOutputModel : AbstractOutputModel
    {
        TOutputModel Use(TInputModel input);
    }
}