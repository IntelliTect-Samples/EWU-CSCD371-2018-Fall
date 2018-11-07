using System;

namespace UniversityCourse.Scheduling 
{
    public readonly struct Schedule
    {
        public Schedule(DaysOfTheWeek daysOfTheWeek, Quarter quarter, Time timespan, TimeSpan duration)
        {
            @DaysOfTheWeek = daysOfTheWeek;
            @Quarter = quarter;
            StartTime = timespan;
            Duration = duration;


        }
        public DaysOfTheWeek @DaysOfTheWeek { get; }
        public Quarter @Quarter { get; }
        public Time StartTime{ get; }
        public TimeSpan Duration { get; }
    }
}