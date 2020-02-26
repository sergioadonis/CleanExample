using System;

namespace CleanExample.Core.Common.Exceptions
{
    public class NameIsEmptyException : Exception
    {
        public NameIsEmptyException() : base("The name is empty") { }
    }
    
    public class NameIsTooLongException : Exception
    {
        public NameIsTooLongException(string name, int maxAllowed) : base("The name is too long")
        {
            Data.Add("Name", name);
            Data.Add("NameLength", name.Length);
            Data.Add("MaxLengthAllowed", maxAllowed);
        }
    }
}
