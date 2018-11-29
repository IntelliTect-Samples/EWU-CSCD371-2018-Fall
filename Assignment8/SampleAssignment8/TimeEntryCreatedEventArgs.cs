using System;

namespace SampleAssignment8
{
    public class TimeEntryCreatedEventArgs : EventArgs
    {
        public TimeEntryCreatedEventArgs(TimeSpan duration)
        {
            Duration = duration;
        }

        public TimeSpan Duration { get; }
    }
}