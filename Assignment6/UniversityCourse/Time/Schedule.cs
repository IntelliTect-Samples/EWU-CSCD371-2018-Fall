using System;

namespace UniversityCourse.Time
{
    public struct Schedule
    {
        public Schedule(DaysOfTheWeek daysOfTheWeek, Quarter quarter, Time timespan, TimeSpan duration)
        {
            @DaysOfTheWeek = daysOfTheWeek;
            @Quarter = quarter;
            StartTime = timespan;
            Duration = duration;


        }
        public DaysOfTheWeek @DaysOfTheWeek { get; private set; }
        public Quarter @Quarter { get; private set; }
        public Time StartTime{ get; private set; }
        public TimeSpan Duration { get; private set; }
    }
}