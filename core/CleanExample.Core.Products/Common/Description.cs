using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace CleanExample.Core.Products.Common
{
    [DebuggerDisplay("{" + nameof(_value) + "}")]
    public class Description : ValueObject, IEquatable<Description>, IEquatable<string>
    {
        private readonly string _value;

        private Description(string value)
        {
            this._value = string.IsNullOrEmpty(value) ? string.Empty : value.Trim();
        }

        public override string ToString()
        {
            return _value;
        }

        #region Conversion

        public static implicit operator string(Description value)
        {
            return value._value;
        }

        public static implicit operator Description(string value)
        {
            return new Description(value);
        }

        #endregion

        #region Equality

        public static bool operator ==(Description a, Description b)
        {
            if (ReferenceEquals(a, b)) return true;
            if (((object) a == null) || ((object) b == null)) return false;

            return a._value == b._value;
        }

        public static bool operator !=(Description a, Description b) => !(a == b);


        bool IEquatable<string>.Equals(string other)
        {
            return other == _value;
        }

        bool IEquatable<Description>.Equals(Description other)
        {
            return other != null && other._value == _value;
        }

        public override bool Equals(object obj)
        {
            var description = obj as Description;
            return description != null &&
                   base.Equals(obj) &&
                   _value == description._value;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(base.GetHashCode(), _value);
        }

        protected override IEnumerable<object> GetAtomicValues()
        {
            yield return _value;
        }

        #endregion
    }
}