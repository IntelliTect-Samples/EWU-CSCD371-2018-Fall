using System;

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
                if (value.CompareTo(DateEnd) < 0)
                    throw new ArgumentOutOfRangeException($"Start date cannot be after end date: {value}", nameof(value));
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
                    throw new ArgumentOutOfRangeException($"End date cannot be before start date: {value}", nameof(value));
                _DateEnd = value;
            }
        }

        private string _Name;
        public string Name
        {
            get { return _Name; }
            private set {
                if (value is null)
                    throw new ArgumentNullException("The event name cannot be null");
                if (value.Length < 4)
                    throw new ArgumentOutOfRangeException($"The event name must be atleast 4 characters: {value}", nameof(value));
                _Name = value;
            }
        }
        private string _Location;
        public string Location
        {
            get { return _Location; }
            private set
            {
                if (value is null)
                    throw new ArgumentNullException("The location cannot be null");
                if (value.Length < 3)
                    throw new ArgumentOutOfRangeException($"The locations must be atleast 3 characters: {value}", nameof(value));
                _Location = value;
            }
        }


        public Event(string name, string location, DateTime dateStart, DateTime dateEnd)
        {
            Name = name;
            Location = location;
            DateStart = dateStart;
            DateEnd = dateEnd;
            NumberOfEvents++;
        }

        public void Deconstruct(out string name, out string location, out DateTime start, out DateTime end)
        {
            (name, location, start, end) =
                (Name, Location, DateStart, DateEnd);
        }

        public virtual string GetSummaryInformation()
        {
            return $"Event Name: {Name}\nLocation: {Location}\nStart Date: {DateStart}\nEnd Date: {DateEnd}";
        }
    }
}
