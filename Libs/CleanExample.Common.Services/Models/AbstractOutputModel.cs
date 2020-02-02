namespace CleanExample.Common.Services.Models
{
    public abstract class AbstractOutputModel
    {
        public StatusCode Status { get; set; }

        public string Message { get; set; } = "";
    }
}