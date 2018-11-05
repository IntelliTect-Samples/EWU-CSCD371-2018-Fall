using System;
using System.Collections.Generic;
using System.IO;

namespace Assignment6
{
    public class UniversityCourse : IEvent
    {
        private enum Day
        {
            Sun,
            Mon,
            Tues,
            Weds,
            Thurs,
            Fri,
            Sat
        };

        private enum SchoolQuarter
        {
            Fall,
            Winter,
            Spring,
            Summer
        };

        readonly struct TimeValue
        {
            public int Hour { get; }
            public int _minute { get; }
            public int _second { get; }

            public TimeValue(int hour, int minute, int second)
            {
                Hour = hour;
                _minute = minute;
                _second = second;
            }
        }

        readonly struct Schedule
        {
            // List so we can have multiple days
            public List<Day> _daysOfWeek { get; }
            public SchoolQuarter _quarter { get; }
            public TimeValue _startTime { get; }
            public TimeSpan _duration { get; }

            public Schedule(List<Day> daysOfWeek, SchoolQuarter quarter, int startingHour, int startingMinute, 
                int startingSecond, int durationHours, int durationMinutes, int durationSeconds)
            {
                _daysOfWeek = daysOfWeek;
                _quarter = quarter;

                if (startingHour <= 24 && startingHour > 0 && startingMinute < 60 && startingMinute >= 0 
                    && startingSecond < 60 && startingSecond >= 0)
                {
                    _startTime = new TimeValue(startingHour, startingMinute, startingSecond);
                }
                else
                {
                    throw new InvalidDataException("Starting time is out of valid time range! Valid range: " +
                                                   "Hour (0-24), Minute (0-60), Seconds (0-60)");
                }
                
                _duration = new TimeSpan(durationHours, durationMinutes, durationSeconds);
            }
            
            public Schedule(string daysOfWeek, string quarter, TimeValue startTime, TimeSpan duration)
            {
                _daysOfWeek = ConvertStringToDayList(daysOfWeek);
                _quarter = ConvertStringToSchoolQuarter(quarter);
                _startTime = startTime;
                _duration = duration;
            }

            private static List<Day> ConvertStringToDayList(string spaceDelimitedDayList)
            {
                List<Day> newDayList = new List<Day>();
        
                string[] separatedDays = spaceDelimitedDayList.Split();

                foreach (string cur in separatedDays)
                {
                    if (Enum.TryParse(cur, out Day parsedDay))
                    {
                        newDayList.Add(parsedDay);
                    }
                    else
                    {
                        var validDays = Enum.GetValues(typeof(Day));
                        string validDayValues = "";

                        foreach (var enumValue in validDays)
                        {
                            validDayValues += enumValue + " ";
                        }

                        validDayValues = validDayValues.Trim();
                        throw new InvalidDataException($"{cur} is an invalid Day. Valid days are: \"{validDayValues}\"");
                    }
                }

                return newDayList;
            }
            
            private static SchoolQuarter ConvertStringToSchoolQuarter(string schoolQuarter)
            {
                if (Enum.TryParse(schoolQuarter, out SchoolQuarter quarter))
                {
                    return quarter;
                }
                
                // if not a valid type
                var validQuarters = Enum.GetValues(typeof(SchoolQuarter));
                string validQuarterTypes = "";

                foreach (var enumValue in validQuarters)
                {
                    validQuarterTypes += enumValue + " ";
                }

                validQuarterTypes = validQuarterTypes.Trim();
                throw new InvalidDataException($"{schoolQuarter} is an invalid SchoolQuarter. Valid quarters are: \"{validQuarterTypes}\"");
            }
        }

        private readonly Schedule _currentSchedule;

        public void SetSchedule(string daysToSet)
        {
            List<Day> newDayList = new List<Day>();

            string[] separatedDays = daysToSet.Split();

            foreach (string cur in separatedDays)
            {
                Day parsedDay;
                if (Enum.TryParse(cur, out parsedDay))
                {
                    newDayList.Add(parsedDay);
                }
                else
                {
                    var validDays = Enum.GetValues(typeof(Day));
                    string validDayValues = "";

                    foreach (var enumValue in validDays)
                    {
                        validDayValues += enumValue + " ";
                    }

                    validDayValues = validDayValues.Trim();
                    throw new InvalidDataException($"{cur} is an invalid Day. Valid days are: \"{validDayValues}\"");
                }
            }
        }

        // Read only
        public int Crn { get; }
        
        // Calculated property
        // 2 hours of homework expected for every hour of class time
        public int DailyHoursOfHomeworkExpected 
            => (_currentSchedule._duration.Hours+(_currentSchedule._duration.Minutes/60)) * 2;
        
        public UniversityCourse(int crn, DateTime startingTime, DateTime endingTime) 
        {
            this.Crn = crn;
        }

        //TODO: Update
        public string GetSummaryInformation()
        {
            string daysOfWeekEventOccursOn = "";
            /*foreach (char cur in DaysOfWeek)
            {
                daysOfWeekEventOccursOn += cur + " ";
            }*/
            
            return 
$@"The course CRN is: {Crn}
It repeats on {daysOfWeekEventOccursOn}
Expect {DailyHoursOfHomeworkExpected} hours of homework each day.";
        }

        // TODO
        public int GetStartingHour()
        {
            throw new NotImplementedException();
        }

        // TODO:
        public int GetEndingHour()
        {
            throw new NotImplementedException();
        }
    }
}