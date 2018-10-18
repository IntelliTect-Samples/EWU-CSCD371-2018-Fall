using System;
using System.Collections.Generic;
using System.IO;

namespace Assignment4
{
    public class UniversityCourse : Event
    {
        // Read only
        public int Crn { get; }
        
        // Validated property
        public List<char> DaysOfWeek
        {
            get => _daysOfWeek;

            set
            {
                if (value.Count > 5)
                {
                    throw new InvalidDataException("Maximum number of days is 5!");
                }
                
                // NOTE: Saturday and Sunday are not valid school days
                List<char> validDaysOfWeek = new List<char> {'M', 'T', 'W', 'R', 'F'};
                foreach (char cur in value)
                {
                    if (!validDaysOfWeek.Contains(cur))
                    {
                        throw new InvalidDataException($"{cur} is not a valid day of the week!");
                    }
                }

                _daysOfWeek = value;
            }
        }
        
        // Calculated property
        public int DailyHoursOfHomeworkExpected
        {
            get { return DaysOfWeek.Count * (TimeRange.startTime.Hour - TimeRange.endTime.Hour); }
        }

        private List<char> _daysOfWeek;
        
        public UniversityCourse(int CRN, DateTime startingTime, DateTime endingTime) : base(startingTime, endingTime)
        {
            if (CRN.ToString().Length != 5)
            {
                throw new InvalidDataException("CRN must be 5 digit value!");
            }

            this.Crn = CRN;
        }

        public new string GetSummaryInformation()
        {
            string daysOfWeekEventOccursOn = "";
            foreach (char cur in DaysOfWeek)
            {
                daysOfWeekEventOccursOn += cur + " ";
            }
            
            return $"The course CRN is: {Crn}{System.Environment.NewLine}" +
                   $"{base.GetSummaryInformation()}{System.Environment.NewLine} " +
                   $"It repeats on {daysOfWeekEventOccursOn}" +
                   $"Expect {DailyHoursOfHomeworkExpected} hours of homework each day.";
        }
    }
}