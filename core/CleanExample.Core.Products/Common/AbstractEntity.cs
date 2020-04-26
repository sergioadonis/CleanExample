using System;

namespace CleanExample.Core.Products.Common
{
    public abstract class AbstractEntity
    {
        public Guid Id { get; protected set; } = Guid.Empty;

        protected static string CleanWhiteSpace(string value) =>
            string.IsNullOrWhiteSpace(value) ? string.Empty : value.Trim();
    }
}