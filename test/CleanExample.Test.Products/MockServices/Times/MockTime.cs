using System;
using CleanExample.Core.Common.Times;

namespace CleanExample.Test.Products.MockServices.Times
{
    public class MockTime : ITime
    {
        public DateTime GetCurrentTime()
        {
            return DateTime.Now;
        }
    }
}