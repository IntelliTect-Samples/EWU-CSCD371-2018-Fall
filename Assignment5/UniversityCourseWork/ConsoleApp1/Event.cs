using System;
using System.IO;

namespace ConsoleApp1
{
    public class Event
    {
        public int EventCount { get; private set; }
        private (DateTime startTime, DateTime endTime) time;
        public string title { get; private set; }

        public Event (string title, DateTime startTime, DateTime endTime)
        {
            this.title = title;
            SetTime(startTime, endTime);
            EventCount++;
        }

        public void Destruct()
        {
            EventCount--;
        }

        public void SetTime (DateTime startTime, DateTime endTime)
        {
            /*if (startTime.Hour > endTime.Hour || startTime.Day > endTime.Day || startTime.Month > endTime.Month || startTime.Year > endTime.Year)
            {
                throw new InvalidDataException("The event must start before it ends");
            }*/

            time.startTime = startTime;
            time.endTime = endTime;
        }

        internal string GetSummaryInformation()
        {
            return $"Starts at {time.startTime.Hour}:{time.startTime.Minute} and ends at {time.endTime.Hour}:{time.endTime.Minute}";
        }

        internal string GetDays()
        {
            return $"Start date is {time.startTime.Year} {time.startTime.Month} {time.startTime.Minute} and ends on {time.endTime.Year} {time.endTime.Month} {time.endTime.Day}";
        }
    }
}