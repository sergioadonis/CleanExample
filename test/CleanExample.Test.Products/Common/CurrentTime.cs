using System;
using CleanExample.Core.Products.Common;

namespace CleanExample.Test.Products.Common
{
    public class CurrentTime : ITime
    {
        public DateTime GetCurrentTime()
        {
            return DateTime.Now;
        }
    }
}