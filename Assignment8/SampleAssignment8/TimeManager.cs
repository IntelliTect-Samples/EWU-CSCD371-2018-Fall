using System;

namespace SampleAssignment8
{
    public class TimeManager
    {
        private readonly IDateTime _DateTime;
        private DateTime? _StartTime;

        public event EventHandler<TimeEntryCreatedEventArgs> TimeEntryCreated;

        public TimeManager(IDateTime dateTime)
        {
            _DateTime = dateTime ?? throw new ArgumentNullException(nameof(dateTime));
        }

        public Status MarkTime()
        {
            if (_StartTime == null)
            {
                _StartTime = _DateTime.Now;
                return Status.Running;
            }

            var duration = _DateTime.Now - _StartTime;
            _StartTime = null;
            TimeEntryCreated?.Invoke(this, new TimeEntryCreatedEventArgs(duration.Value));
            return Status.NotRunning;
        }
    }
}