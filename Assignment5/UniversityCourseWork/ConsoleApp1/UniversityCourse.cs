using System;
using System.Collections.Generic;
using System.IO;

namespace ConsoleApp1
{
    public class UniversityCourse : Event
    {
        public int courseNumber { get; private set; }
        private List<char> _schoolDays;

        public List<char> SchoolDays
        {
            get => _schoolDays;
            set
            {
                if (value.Count > 5)
                {
                    throw new InvalidDataException("Too many class days");
                }
                
                List<char> validSchoolDays = new List<char> { 'M', 'T', 'W', 'R', 'F' };
                foreach (char cur in value)
                {
                    if (!validSchoolDays.Contains(cur))
                    {
                        throw new InvalidDataException($"{cur} is not a valid day of the week");
                    }
                }
                _schoolDays = value;
            }
        }

        public UniversityCourse(string title, int courseNumber, DateTime startTime, DateTime endTime, List<char> SchoolDays) : base(title, startTime, endTime)
        {
            this.courseNumber = courseNumber;
            this.SchoolDays = SchoolDays;
        }

        public string GetSummaryInformation()
        {
            string days = "";

            foreach(char cur in SchoolDays)
            {
                days += cur;
            }

            return
                $"Title : {base.title}\n" +
                $"Course number : {courseNumber}\n" +
                $"It's taught on: {days}\n" +
                $"{base.GetSummaryInformation()}\n";
        }
    }
}
