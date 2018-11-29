using System;

namespace Assignment5
{
    public class Event : IEvent
    {
        public Event(string name, string location, DateTime date)
        {
            Name = name;
            Location = location;
            Date = date;
        }

        public string Name { get; }

        public string Location { get; }

        public DateTime Date { get; }

        public override string ToString()
        {
            return $"Event: {Name} at {Location} on {Date:d}";
        }
    }
}