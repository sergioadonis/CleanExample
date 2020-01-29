namespace CleanExample.Common.UseCases.Models
{
    public abstract class AbstractInputModel
    {
        public string UserName { get; set; }

        public string IpAdress { get; set; }
        
        public string Trace { get; set; }
    }
}