using CleanExample.Common.Services.Models;

namespace CleanExample.Common.Services.UseCases
{
    public interface IUseCase<TInputModel, TOutputModel> where TInputModel : AbstractModel where TOutputModel : AbstractModel
    {
        TOutputModel Use(TInputModel input);
    }
}