using System;
﻿using System.Text.Json;

namespace CleanExample.Common.Entities
{
    public abstract class BaseEntity : IEntity
    {
        protected JsonSerializerOptions jsonOptions = new JsonSerializerOptions
        {
            WriteIndented = true
        };
        
        public string Id;
        
        public DateTime CreatedAt;
        
        public DateTime UpdatedAt;
        
        public DateTime DeletedAt;
    }
}