namespace CleanExample.Core.Products.Contracts
{
    public interface IService<in TInput, out TOutput>
    {
        TOutput Invoke(TInput input);
    }
}

//where TInputModel : AbstractModel where TOutputModel : AbstractModel