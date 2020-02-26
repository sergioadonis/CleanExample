using CleanExample.Core.Common.Models;

namespace CleanExample.Core.Common.UseCases
{
    public interface IUseCase<TInputModel, TOutputModel> where TInputModel : AbstractModel where TOutputModel : AbstractModel
    {
        TOutputModel Use(TInputModel input);
    }
}