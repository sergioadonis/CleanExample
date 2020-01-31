using CleanExample.Common.UseCases.Models;

namespace CleanExample.Common.UseCases
{
    public abstract class AbstractUseCase<TInputModel, TOutputModel> where TInputModel : AbstractInputModel where TOutputModel : AbstractOutputModel
    {
        public abstract TOutputModel Use(TInputModel input);
    }
}