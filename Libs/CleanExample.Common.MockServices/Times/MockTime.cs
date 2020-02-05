using CleanExample.Common.Services.Time;
using System;

namespace CleanExample.Common.MockServices.Time
{
    public class MockTime : ITime
    {
        public DateTime GetCurrentTime()
        {
            return DateTime.Now;
        }
    }
}