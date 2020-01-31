using System;

namespace CleanExample.Common.Interfaces.Time
{
    public class CurrentTime : ITime
    {
        public DateTime GetCurrentTime()
        {
            return DateTime.Now;
        }
    }
}