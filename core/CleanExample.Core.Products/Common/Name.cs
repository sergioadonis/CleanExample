using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace CleanExample.Core.Products.Common
{
    [DebuggerDisplay("{" + nameof(_value) + "}")]
    public class Name : ValueObject, IEquatable<Name>, IEquatable<string>
    {
        private readonly string _value;

        private Name(string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new ArgumentNullException(nameof(Name));
            }

            var name = value.Trim();
            var nameLength = name.Length;
            const int max = 50;
            if (nameLength > max)
                throw new ArgumentException("Name is too long", nameof(Name));

            _value = name;
        }

        public override string ToString()
        {
            return _value;
        }

        #region Conversion

        public static implicit operator string(Name value)
        {
            return value._value;
        }

        public static implicit operator Name(string value)
        {
            return new Name(value);
        }

        #endregion

        #region Equality

        public static bool operator ==(Name a, Name b)
        {
            if (ReferenceEquals(a, b)) return true;
            if (((object) a == null) || ((object) b == null)) return false;

            return a._value == b._value;
        }

        public static bool operator !=(Name a, Name b) => !(a == b);


        bool IEquatable<string>.Equals(string other)
        {
            return other == _value;
        }

        bool IEquatable<Name>.Equals(Name other)
        {
            return other != null && other._value == _value;
        }

        public override bool Equals(object obj)
        {
            var name = obj as Name;
            return name != null &&
                   base.Equals(obj) &&
                   _value == name._value;
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