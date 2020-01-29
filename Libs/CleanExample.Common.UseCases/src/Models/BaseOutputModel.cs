namespace CleanExample.Common.UseCases.Models
{
    public abstract class BaseOutputModel : IModel
    {
        public StatusCode Status { get; set; }

        public string Message { get; set; }
    }
}