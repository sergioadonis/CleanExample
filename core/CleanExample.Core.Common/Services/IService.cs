namespace CleanExample.Core.Common.Services
{
    public interface IService<in TInputModel, out TOutputModel>
    {
        TOutputModel Invoke(TInputModel input);
    }
}

//where TInputModel : AbstractModel where TOutputModel : AbstractModel