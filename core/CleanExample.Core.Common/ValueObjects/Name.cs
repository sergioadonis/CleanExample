using CleanExample.Core.Common.Exceptions;
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace CleanExample.Core.Common.ValueObjects
{
    [DebuggerDisplay("{Value}")]
    public class Name : ValueObject, IEquatable<Name>, IEquatable<string>
    {
        public string Value { get; }

        public Name(string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new NameIsEmptyException();
            }

            var name = value.Trim();
            var nameLength = name.Length;
            var max = 50;
            if (nameLength > max)
                throw new NameIsTooLongException(name, max);

            Value = name;
        }

        public override string ToString()
        {
            return Value.ToString();
        }

        #region Conversion

        public static implicit operator string(Name value)
        {
            return value.Value;
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
            if (((object)a == null) || ((object)b == null)) return false;

            return a.Value == b.Value;
        }

        public static bool operator !=(Name a, Name b) => !(a == b);

        protected override IEnumerable<object> GetAtomicValues()
        {
            yield return Value;
        }

        bool IEquatable<string>.Equals(string other)
        {
            return other == Value;
        }

        bool IEquatable<Name>.Equals(Name other)
        {
            return other != null && other.Value == Value;
        }

        public override bool Equals(object obj)
        {
            var name = obj as Name;
            return name != null &&
                   base.Equals(obj) &&
                   Value == name.Value;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(base.GetHashCode(), Value);
        }

        #endregion

    }
}
