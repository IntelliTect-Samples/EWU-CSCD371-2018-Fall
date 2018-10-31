using System;
using System.Collections.Generic;
using System.IO;

namespace Assignment5
{
    // NOTE: IEvent extension is not needed here since Event already extends IEvent
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

                if (value.Count < 1)
                {
                    throw new InvalidDataException("Must occur on at least 1 day!");
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
        // 2 hours of homework expected for every hour of class time
        public int DailyHoursOfHomeworkExpected 
            => ((TimeRange.endTime.Hour - TimeRange.startTime.Hour)) * 2;

        private List<char> _daysOfWeek;
        
        public UniversityCourse(int crn, DateTime startingTime, DateTime endingTime, List<char> daysOfWeek) 
            : base(startingTime, endingTime)
        {
            this.Crn = crn;
            this.DaysOfWeek = daysOfWeek;
        }

        public override string GetSummaryInformation()
        {
            string daysOfWeekEventOccursOn = "";
            foreach (char cur in DaysOfWeek)
            {
                daysOfWeekEventOccursOn += cur + " ";
            }
            
            return 
$@"The course CRN is: {Crn}
{base.GetSummaryInformation()}
It repeats on {daysOfWeekEventOccursOn}
Expect {DailyHoursOfHomeworkExpected} hours of homework each day.";
        }
    }
}