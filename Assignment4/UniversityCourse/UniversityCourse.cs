using System;
using System.Text.RegularExpressions;

namespace Assignment4
{
    public class UniversityCourse : Event
    {
        public static int NumberOfCourses { get; private set; } = 0;

        private string _CourseID;
        public string CourseID
        {
            get { return _CourseID; }
            set {
                if (value is null)
                    throw new ArgumentNullException("The course ID cannot be null", nameof(value));
                if(!Regex.IsMatch(value, @"\w{4}\d{3}"))
                    throw new ArgumentException($"The course ID must be 4 characters followed by 3 digits: {value}", nameof(value));
                _CourseID = value;
            }
        }


        private string _Instructor;
        public string Instructor
        {
            get { return _Instructor; }
            set {
                if (value is null)
                    throw new ArgumentNullException("The instructor name cannot be null", nameof(value));
                value = value.Trim();
                if (value.Length < 2)
                    throw new ArgumentOutOfRangeException($"The instructor name must be atleast 2 characters: {value}", nameof(value));
                _Instructor = value;
            }
        }


        private string _Schedule;
        public string Schedule
        {
            get { return _Schedule; }
            set {
                if (value is null)
                    throw new ArgumentNullException("The schedule cannot be null", nameof(value));
                value = value.Trim();
                if (value.Length < 1 || value.Length > 7)
                    throw new ArgumentOutOfRangeException($"The course must meet atleast once a week and less than 8", nameof(value));
                _Schedule = value;
            }
        }

        private int _NumberOfCredits;
        public int NumberOfCredits
        {
            get {
                var daysPerWeek = Schedule.Length;
                var hoursPerDay = (DateEnd - DateStart).TotalHours;
                return (int)(daysPerWeek * hoursPerDay);
            }
        }


        public UniversityCourse(string name, string location, DateTime dateStart, DateTime dateEnd,
            string courseId, string instructor, string schedule) : 
            base(name, location, dateStart, dateEnd)
        {
            CourseID = courseId;
            Instructor = instructor;
            Schedule = schedule;
            NumberOfCourses++;
        }

        public override string GetSummaryInformation()
        {
            return base.GetSummaryInformation() + 
                $"Course ID: {CourseID}\nInstructor: {Instructor}\nSchedule: {Schedule}\n Number of Credits: {NumberOfCredits}";
        }
    }
}
