using CleanExample.Common.Services.Time;
using System;

namespace CleanExample.Common.Services.Mocks.Time
{
    public class MockTime : ITime
    {
        public DateTime GetCurrentTime()
        {
            return DateTime.Now;
        }
    }
}