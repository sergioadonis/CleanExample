using CleanExample.Core.Common.Time;
using System;

namespace CleanExample.Test.Products.MockServices.Time
{
    public class MockTime : ITime
    {
        public DateTime GetCurrentTime()
        {
            return DateTime.Now;
        }
    }
}