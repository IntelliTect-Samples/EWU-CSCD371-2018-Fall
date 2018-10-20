using System;
using System.Collections.Generic;
using System.Text;

namespace Assignment4
{
    public class Event
    {

        public static int NumberOfEvents { get; private set; } = 0;

        private DateTime _DateStart;
        public DateTime DateStart
        {
            get { return _DateStart; }
            private set
            {
                if (value.CompareTo(DateEnd) > 0)
                    throw new ArgumentOutOfRangeException($"Start date cannot be after end date: {value}");
                _DateStart = value;
            }
        }

        private DateTime _DateEnd;
        public DateTime DateEnd
        {
            get { return _DateEnd; }
            private set
            {
                if (value.CompareTo(DateStart) < 0)
                    throw new ArgumentOutOfRangeException($"End date cannot be before start date: {value}");
                _DateEnd = value;
            }
        }

        private string _Name;
        public string Name
        {
            get { return _Name; }
            private set {
                if (value is null)
                    throw new ArgumentNullException($"The event name cannot be null");
                if (value.Length < 4)
                    throw new ArgumentOutOfRangeException($"The event name must be atleast 4 characters: {value}");
                _Name = value;
            }
        }

        public Event(string name, DateTime dateStart, DateTime dateEnd)
        {
            Name = name;
            DateStart = dateStart;
            DateEnd = dateEnd;
            NumberOfEvents++;
        }

        public string GetSummaryInformation()
        {
            return $"Event Name: {Name}\nStart Date: {DateStart}\nEnd Date: {DateEnd}";
        }
    }
}
