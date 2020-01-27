using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace CleanExample.Common.UseCases.Models
{
    public abstract class BaseOutputModel : IModel
    {
        public StatusCode Status { get; set; }
        
        public string Message { get; set; }
        
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