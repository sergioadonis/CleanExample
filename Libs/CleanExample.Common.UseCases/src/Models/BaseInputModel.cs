namespace CleanExample.Common.UseCases.Models
{
    public abstract class BaseInputModel : IModel
    {
        public string UserName { get; set; }

        public string IpAdress { get; set; }
    }
}