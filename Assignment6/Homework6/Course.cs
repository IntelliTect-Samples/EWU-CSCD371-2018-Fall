using System;
using System.Collections.Generic;
using System.Text;

namespace Homework6
{   
    public class Course : UniversityCalender , IEvent
    {
        public Course(string name, string courseNumber, string courseSchedule, string instructorUserName)
        {
            _CourseNumber = courseNumber;
            Name = name;
            CourseSchedule = courseSchedule;
            InstructorUserName = instructorUserName;
            incTotalCalendarItems();
        }

        public string CourseNumber
        {
            get
            {
                return _CourseNumber;
            }
        }
        private string _CourseNumber;
        
        public string CourseSchedule { get; set; }
        public string InstructorFirstName { get; set; }
        public string InstructorLastName { get; set; }
        public string InstructorUserName
        {
            get
            {
                return $"{InstructorFirstName}.{InstructorLastName}";
            }
            set
            {
                if (value is null)
                {
                    throw new ArgumentNullException(nameof(InstructorUserName));
                }
                (InstructorFirstName, InstructorLastName) = ParseName(value);
            }
        }

        public int StudentCount  //Satifies the data Validation requirement
        {
            get{
                return _StudentCount;
            }
            set
            {
                if (value <= 11)
                {
                    throw new ArgumentException("Class size of less than 12 students is not allowed.", "value");
                }
                else if (value >= 37)
                {
                    throw new ArgumentException("Class size of more than 36 students is not allowed.", "value");
                }
                else
                {
                    System.Console.WriteLine("DEBUG - StudentCount in the setter is " + value);
                    _StudentCount = value;
                    
                }
            }
        }
        private int _StudentCount;

        public int InstructorSalory
        {
            get
            {
                return _InstructorSalory;
            }
            set
            {
                _InstructorSalory = value + (StudentCount / 10) * 1000;
            } //Extra $1000 per 10 students
        }
        private int _InstructorSalory;

        public override string Display()
        {
            return GetSummaryInformation();
        }

        public string GetSummaryInformation()
        {
            return "COURSE: " + CourseNumber + "| " + Name + "| " + InstructorLastName
                + ", " + InstructorFirstName + "| " + CourseSchedule;
        }

        //This deconstructor was adapted from the Lecture code posted to Git.
        private (string FirstName, string LastName) ParseName(string value)
        {
            int separatorIndex = value.IndexOf('.');
            if (separatorIndex < 2 || separatorIndex > value.Length - 2)
            {
                throw new ArgumentException(nameof(InstructorUserName),
                    "InstructorUserName must be of the format <FirstName>.<LastName>");
            }
            else
            {
                return (FirstName: value.Substring(0, separatorIndex),
                    LastName: value.Substring(separatorIndex + 1,
                    value.Length - separatorIndex - 1));
            }
        }

        public void RoomsRescourseValidator()
        {
            System.Console.WriteLine("Rooms resouces verified for the " + Name + " course, no scheduling conficts.");
        }

    }//end of course class
}
