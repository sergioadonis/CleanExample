using CleanExample.Common.Services.Time;
using System;

namespace CleanExample.ConsoleApp.Time
{
    public class CurrentTime : ITime
    {
        public DateTime GetCurrentTime()
        {
            return DateTime.Now;
        }
    }
}