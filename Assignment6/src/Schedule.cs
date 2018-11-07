using System;
namespace Assignment6
{
        public readonly struct Schedule
        {
            public readonly Days DaysOfWeek;
            public readonly Quarters Quarter;
            public readonly Time StartTime;
            public readonly TimeSpan Duration;

            public Schedule(Days days, Quarters quarters, Time time, TimeSpan duration)
            {
                this.DaysOfWeek = days;
                this.Quarter = quarters;
                this.StartTime = time;
                this.Duration = duration;
            }
 
        }
}