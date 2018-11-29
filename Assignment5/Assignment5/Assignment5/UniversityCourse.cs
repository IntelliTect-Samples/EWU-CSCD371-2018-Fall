using System;

namespace Assignment5
{
    public class UniversityCourse : IEvent
    {
        public UniversityCourse(string name, string location, DateTime startDate, DateTime endDate)
        {
            Name = name;
            Location = location;
            StartDate = startDate;
            EndDate = endDate;
        }

        public string Name { get; }

        public string Location { get; }

        public DateTime StartDate { get; }

        public DateTime EndDate { get; }

        public override string ToString()
        {
            return $"University course: {Name} at {Location} from {StartDate:d} to {EndDate:d}";
        }
    }
}