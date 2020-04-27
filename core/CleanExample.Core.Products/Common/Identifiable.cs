﻿using System;

namespace CleanExample.Core.Products.Common
{
    public abstract class Identifiable<TId> where TId : IEquatable<TId>
    {
        protected Identifiable(TId id)
        {
            Id = id ?? throw new ArgumentNullException(nameof(id));
        }

        public TId Id { get; }
    }
}