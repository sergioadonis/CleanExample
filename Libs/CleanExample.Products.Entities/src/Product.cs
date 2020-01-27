using System;
﻿using System.Text.Json;
﻿using CleanExample.Common.Entities;

namespace CleanExample.Products.Entities
{
    public class Product : BaseEntity
    {
        public string Name { get; set; }
        
        public string Description { get; set; }
        
        public override string ToString()
        {
            return JsonSerializer.Serialize(this, jsonOptions);
        }
    }
}
