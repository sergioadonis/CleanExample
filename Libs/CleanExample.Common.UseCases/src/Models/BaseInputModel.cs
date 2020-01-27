using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace CleanExample.Common.UseCases.Models
{
    public abstract class BaseInputModel : IModel
    {
        public string UserName { get; set; }
        
        public string IpAdress { get; set; }
        
        public override string ToString()
        {
            var options = new JsonSerializerOptions()
            {
                WriteIndented = true,
            };
            return JsonSerializer.Serialize(this, options);
        }
    }
}