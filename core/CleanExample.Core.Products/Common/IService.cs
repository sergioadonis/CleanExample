namespace CleanExample.Core.Products.Common
{
    public interface IService<in TInputModel, out TOutputModel>
    {
        TOutputModel Invoke(TInputModel input);
    }
}

//where TInputModel : AbstractModel where TOutputModel : AbstractModel